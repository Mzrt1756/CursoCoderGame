using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] private float moveSpeed;
    /*[SerializeField] private float force;*/
    [SerializeField] private float dragSpeed;
    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Ground Check
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    bool grounded;

    //Player Properties
    [SerializeField] private Light mLight;
    [SerializeField] private GameObject MagicLight;
    [SerializeField] private SphereCollider magicLightCollider;
    [SerializeField] private Canvas m_deathText;
    private float health = 200f;
    private float mana = 200f;
    //[SerializeField] public float GameManager.instance._maxHealth = 200f;
    //[SerializeField] public float GameManager.instance._maxMana = 200f;
    private Vector3 magicLightOrigin;
    private float cooldownTimer=10f;
    private string keyCode;
    
    //Raycast
    [SerializeField] private Transform m_eyeView;
    [SerializeField] private float m_raycastDistance;
    [SerializeField] private LayerMask m_layerToCollideWith;
    [SerializeField] private float m_explosionForce = 2000f;
    [SerializeField] private float m_explosionRadius = 6f;

    //Canvas
    [SerializeField] private Canvas inventory;


    private void Start()
    {
        GameManager.instance.ObtainPlayerReference(this);
        GameManager.instance.SavePlayerState(health, mana);
        magicLightOrigin = new Vector3(3.65f,8.34f,11.13f);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        health = GameManager.instance._remainingHealth;
        mana = GameManager.instance._remainingMana;
        GameManager.instance.SavePlayerState(health, mana);
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight* 0.5f+0.2f, whatIsGround);

        MyInput();
        /*SpeedControl();*/

        //handle drag
        /*if (grounded)
        {
            rb.drag = dragSpeed;
        }
        else
        {
            rb.drag = 0;
        }*/
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            
        }

        keyPressed();

       /* if (Input.GetKeyDown(KeyCode.T))
        {
            LightZone();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Cure();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            RestoreMana();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CreateRaycast();
        }*/

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
                CreateRaycast();
                break;
            case "i":
                ShowCanvas();
                break;
            default:              
                break;
        }
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        transform.position += moveDirection * moveSpeed;

        /*rb.AddForce(moveDirection.normalized * moveSpeed * force, ForceMode.Force);*/
    }
    /*private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude>moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }else if(moveDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;

        }
    }*/
    public void LightZone()
    {
        if (GameManager.instance._remainingMana <= 50)
        {
            Debug.Log("Your mana isn't enough.");
        }
        else if (cooldownTimer <= 0 && GameManager.instance._remainingMana >= 50)
        {
            GameManager.instance._remainingMana -= 50;
            mLight.range *= 100f;
            mLight.intensity *= 100f;
            cooldownTimer = 10f;
            StartCoroutine(ReturnToNormal());
            
        }
    }
    public void Cure()
    {
        if (GameManager.instance._remainingMana <= 50)
        {
            Debug.Log("Your mana isn't enough.");
            cooldownTimer = 10f;
        }
        else if (GameManager.instance._remainingHealth>= GameManager.instance._maxHealth)
        {
            Debug.Log("Your health is at maximum.");
            GameManager.instance._remainingHealth = GameManager.instance._maxHealth;
        }
        else if (cooldownTimer <= 0 && GameManager.instance._remainingMana>= 50 && GameManager.instance._remainingHealth <= GameManager.instance._maxHealth)
        {
            MagicLight.transform.position = new Vector3(0, 0, 0);
            MagicLight.transform.localScale = new Vector3(30, 30, 30);
            magicLightCollider.radius *= 50f;
            GameManager.instance._remainingMana -= 50;
            GameManager.instance._remainingHealth = GameManager.instance._maxHealth;
            cooldownTimer = 10f;
            StartCoroutine(ReturnToNormal());
        }
    }
    private void RestoreMana()
    {
        
        if (GameManager.instance._remainingMana == GameManager.instance._maxMana)
        {
            Debug.Log("Your mana is full.");
        }
        else if (cooldownTimer <= 0 && GameManager.instance._remainingMana != GameManager.instance._maxMana)
        {
            GameManager.instance._remainingMana = GameManager.instance._maxMana;
            cooldownTimer = 10f;
        }
        
    }
    public void CheckHealth()
    {
        if (GameManager.instance._remainingHealth <= 0 )
        {
            GameManager.instance._remainingHealth = 0;
            if (gameObject)
            {
                m_deathText.gameObject.SetActive(true);
                moveSpeed = 0;
                mLight.intensity = 0;
                /*Destroy(MagicLight);*/

            }
        }
        else 
        {            
            m_deathText.gameObject.SetActive(false);
        }
    }
    public void CheckMana()
    {
        if (GameManager.instance._remainingMana <= 0)
        {

            GameManager.instance._remainingMana = 0;
        }
    }
    private void CreateRaycast()
    {
        var l_hasCollided = Physics.Raycast(m_eyeView.position, m_eyeView.forward, out RaycastHit p_raycastHitInfo, m_raycastDistance, m_layerToCollideWith);
        if (l_hasCollided)
        {
            Debug.Log($"collided with {p_raycastHitInfo.collider.name}");
            var l_boxRigidbody = p_raycastHitInfo.rigidbody;
            if (l_boxRigidbody != null)
            {
                l_boxRigidbody.AddExplosionForce(m_explosionForce, p_raycastHitInfo.point, m_explosionRadius);
            }
        }
        else
        {
            Debug.Log("Hasn´t collided with anything");
        }
    }
    public IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(5f);
        MagicLight.transform.position = magicLightOrigin;
        MagicLight.transform.localScale = new Vector3(3, 3, 3);
        magicLightCollider.radius = 0.5f;
        mLight.range /= 100f;
        mLight.intensity /= 100f;
    }

    public void ShowCanvas()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.isActiveAndEnabled)
            {
                inventory.gameObject.SetActive(false);
            }
            else
            {
                inventory.gameObject.SetActive(true);
            }
          
        }
    }
}
