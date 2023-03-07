using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character/TyrantData")]
public class TyrantData : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
    public float scaleFactor;
    public int damage;
    public float cooldownTimer;
}
