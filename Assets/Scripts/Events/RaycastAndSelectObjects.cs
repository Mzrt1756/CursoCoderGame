using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAndSelectObjects : MonoBehaviour
{
    [SerializeField] private MainCharacterData mainCharacterData;
    [SerializeField] private Transform m_eyeView;

    void OnEnable()
    {
        PlayerController.OnRaycastActive += CreateRaycast;
        
    }

    private void OnDisable()
    {
        PlayerController.OnRaycastActive -= CreateRaycast;
    }

    void CreateRaycast()
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
    }

  
}
