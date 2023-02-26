using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyrantController : MonoBehaviour
{

    [SerializeField] private Transform rebCharTransform;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float scaleFactor;
    private Vector3 originalPosition;
    private int damage = 2;
    private float cooldownTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

        }
        ExecutePursuit();
    }
    private void ExecutePursuit()
    {
        var vectorToChar = rebCharTransform.position - transform.position;
        var distance = vectorToChar.magnitude;
        LookAtPlayer();
        if (distance >= scaleFactor)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            DamagePlayer(damage);
        }
    }
    private void LookAtPlayer()
    {
        var vectorToChar = rebCharTransform.position - transform.position;
        vectorToChar.y = 0;
        Quaternion rotation = Quaternion.LookRotation(vectorToChar);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    private void DamagePlayer(int damageReceived)
    {
        if(cooldownTimer <= 0 && GameManager.instance._remainingHealth> 0)
        {
            GameManager.instance._remainingHealth -= damageReceived;
        }
        
    }
}
