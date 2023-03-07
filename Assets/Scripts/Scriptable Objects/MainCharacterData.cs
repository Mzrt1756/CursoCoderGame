using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character/MainCharacterData")]
public class MainCharacterData : ScriptableObject
{
    //Player Properties
    public int _maxHealth;
    public int _maxMana;

    //Movement
    public float moveSpeed;
    public float moveRunSpeed;
    public float dragSpeed;

    //Ground Check
    public float playerHeight;
    public LayerMask whatIsGround;

    //Raycast
    public float m_raycastDistance;
    public float m_explosionForce;
    public float m_explosionRadius;
    public LayerMask m_layerToCollideWith;

    //Light
    public Light mLight;
    public GameObject MagicLight;
    public SphereCollider magicLightCollider;

    public float cooldownTimer;
}
