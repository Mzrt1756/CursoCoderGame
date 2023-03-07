using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyrantController : Enemy
{

    [SerializeField] private TyrantData tyrantData;

    [SerializeField] private Transform rebCharTransform;
    [SerializeField] private Vector3 initialRotation;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (tyrantData.cooldownTimer > 0)
        {
            tyrantData.cooldownTimer -= Time.deltaTime;

        }
        ExecutePursuit();
    }
    private void ExecutePursuit()
    {
        var vectorToChar = rebCharTransform.position - transform.position;
        var distance = vectorToChar.magnitude;
        LookAtPlayer();
        if (distance >= tyrantData.scaleFactor)
        {
            transform.position += transform.forward * tyrantData.speed * Time.deltaTime;
        }
        else
        {
            DamagePlayer(tyrantData.damage);
        }
    }
    private void LookAtPlayer()
    {
        var vectorToChar = rebCharTransform.position - transform.position;
        vectorToChar.y = 0;
        Quaternion rotation = Quaternion.LookRotation(vectorToChar);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, tyrantData.rotationSpeed * Time.deltaTime);
    }
    private void DamagePlayer(int damageReceived)
    {
        if(tyrantData.cooldownTimer <= 0 && GameManager.instance._remainingHealth> 0)
        {
            GameManager.instance._remainingHealth -= damageReceived;
        }
        
    }
}
