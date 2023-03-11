using System;
using System.Collections;
using UnityEngine;

public class PlayerController : PlayableCharacter
{
    [SerializeField] private MainCharacterData mainCharacterData;

    //Movement
    private float currentSpeed;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    //Ground Check
    bool grounded;

    //Player Properties
    /*[SerializeField] private Canvas m_deathText;*/
    private int health = 200;
    private int mana = 200;
    private Vector3 magicLightOrigin;
    private string keyCode;

    
    //Raycast
    //[SerializeField] public Transform m_eyeView;


    //Events
    public static event Action OnPlayerDeath;
    public static event Action OnInventoryActive;
    public static event Action OnRaycastActive;
    public static event Action OnPauseActive;

    private void Start()
    {
        GameManager.instance.ObtainPlayerReference(this);
        GameManager.instance.SavePlayerState(health, mana);
        magicLightOrigin = new Vector3(3.65f,8.34f,11.13f);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Run();
    }

    private void Update()
    {
        health = GameManager.instance._remainingHealth;
        mana = GameManager.instance._remainingMana;
        GameManager.instance.SavePlayerState(health, mana);
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, mainCharacterData.playerHeight * 0.5f+0.2f, mainCharacterData.whatIsGround);
        
        if (mainCharacterData.cooldownTimer > 0)
        {
            mainCharacterData.cooldownTimer -= Time.deltaTime;

        }

        MyInput();
        keyPressed();
        Run();
        CheckHealth();
        CheckMana();

    }

    private void keyPressed()
    {
        var input = Input.inputString;
        switch (input)
        {
            case "t":
                LightZone();
                break;
            case "h":
                Cure();
                break;
            case "m":
                RestoreMana();
                break;
            case "r":
                if (OnRaycastActive != null)
                {
                    OnRaycastActive?.Invoke();
                }
                break;
            case "i":
                if (OnInventoryActive != null)
                {
                    OnInventoryActive?.Invoke();
                };
                break;
            case "p":
                if (OnPauseActive != null)
                {
                    OnPauseActive?.Invoke();
                };
                break;
            default:              
                break;
        }
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
        //Run();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        transform.position += moveDirection * currentSpeed;
    }
    public void Run()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = mainCharacterData.moveRunSpeed;
        }
        else
        {
            currentSpeed = mainCharacterData.moveSpeed;
        }
    }
    public void LightZone()
    {
        if (GameManager.instance._remainingMana <= 50)
        {
            Debug.Log("Your mana isn't enough.");
        }
        else if (mainCharacterData.cooldownTimer <= 0 && GameManager.instance._remainingMana >= 50)
        {
            GameManager.instance._remainingMana -= 50;
            mainCharacterData.mLight.range *= 100f;
            mainCharacterData.mLight.intensity *= 100f;
            mainCharacterData.cooldownTimer = 10f;
            StartCoroutine(ReturnToNormal());
            
        }
    }
    public void Cure()
    {
        if (GameManager.instance._remainingMana <= 50)
        {
            Debug.Log("Your mana isn't enough.");
            mainCharacterData.cooldownTimer = 10f;
        }
        else if (GameManager.instance._remainingHealth>= mainCharacterData._maxHealth)
        {
            Debug.Log("Your health is at maximum.");
            GameManager.instance._remainingHealth = mainCharacterData._maxHealth;
        }
        else if (mainCharacterData.cooldownTimer <= 0 && GameManager.instance._remainingMana>= 50 && GameManager.instance._remainingHealth <= mainCharacterData._maxHealth)
        {
            mainCharacterData.MagicLight.transform.position = new Vector3(0, 0, 0);
            mainCharacterData.MagicLight.transform.localScale = new Vector3(30, 30, 30);
            mainCharacterData.magicLightCollider.radius *= 50f;
            GameManager.instance._remainingMana -= 50;
            GameManager.instance._remainingHealth = mainCharacterData._maxHealth;
            mainCharacterData.cooldownTimer = 10f;
            StartCoroutine(ReturnToNormal());
        }
    }
    private void RestoreMana()
    {
        
        if (GameManager.instance._remainingMana == mainCharacterData._maxMana)
        {
            Debug.Log("Your mana is full. ");
            Debug.Log("Timer is " + mainCharacterData.cooldownTimer);

        }
        else if (mainCharacterData.cooldownTimer <= 0 && GameManager.instance._remainingMana != mainCharacterData._maxMana)
        {
            GameManager.instance._remainingMana = mainCharacterData._maxMana;
            Debug.Log("Timer is " + mainCharacterData.cooldownTimer);
            mainCharacterData.cooldownTimer = 10f;
            Debug.Log("Timer is " + mainCharacterData.cooldownTimer);
        }
        
    }
    public void CheckHealth()
    {
        if (GameManager.instance._remainingHealth <= 0 )
        {
            GameManager.instance._remainingHealth = 0;
            if (gameObject)
            {
                currentSpeed = 0;
                if (OnPlayerDeath != null)
                {
                    OnPlayerDeath?.Invoke();
                }
            }
        }
    }
    
    /*private void CreateRaycast()
    {
        var l_hasCollided = Physics.Raycast(m_eyeView.position, m_eyeView.forward, out RaycastHit p_raycastHitInfo, mainCharacterData.m_raycastDistance, mainCharacterData.m_layerToCollideWith);
        if (l_hasCollided)
        {
            Debug.Log($"collided with {p_raycastHitInfo.collider.name}");
            var l_boxRigidbody = p_raycastHitInfo.rigidbody;
            if (l_boxRigidbody != null)
            {
                l_boxRigidbody.AddExplosionForce(mainCharacterData.m_explosionForce, p_raycastHitInfo.point, mainCharacterData.m_explosionRadius);
            }
        }
        else
        {
            Debug.Log("Hasn´t collided with anything");
        }
    }*/
    public IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(5f);
        mainCharacterData.MagicLight.transform.position = magicLightOrigin;
        mainCharacterData.MagicLight.transform.localScale = new Vector3(3, 3, 3);
        mainCharacterData.magicLightCollider.radius = 0.5f;
        mainCharacterData.mLight.range /= 100f;
        mainCharacterData.mLight.intensity /= 100f;
    }
    
}

/*public class PlayerHealthController : MonoBehaviour
{
    public float m_currentHealth;
    public float m_maxHealth;

    public event Action<float> OnHealthChange;

    public PlayerHealthController(float p_maxHealth)
    {
        m_maxHealth = p_maxHealth;
        m_currentHealth = p_maxHealth;
    }

    public float GetCurrentHealth()
    {
        return m_currentHealth;
    }

    public void ReceiveDamage(float p_currentDamage)
    {
        m_currentHealth -= p_currentDamage;
        OnHealthChange?.Invoke(m_currentHealth);
    }

    public void HealDamage(float p_currentHeal)
    {
        m_currentHealth += p_currentHeal;
        OnHealthChange?.Invoke(m_currentHealth);

    }
}*/