using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericModel : MonoBehaviour
{
    [SerializeField] private MainCharacterData mainCharacterData;
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_jumpForce;

    public void GetControllerRef(GenericController p_controller)
    {
        p_controller.OnJump += OnJumpHandler;
        p_controller.OnRotate += OnRotateHandler;
        p_controller.OnMoveInput += OnMoveHandler;
    }
    private void OnMoveHandler(float p_movementAmount)
    {
        var transform1 = transform;
        transform1.position += transform1.forward * (p_movementAmount * mainCharacterData.moveSpeed * Time.deltaTime);
    }

    private void OnJumpHandler()
    {
        m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
    }

    private void OnRotateHandler(float p_rotationAmount)
    {
        transform.Rotate(Vector3.up * p_rotationAmount, Space.Self);
    }

}
