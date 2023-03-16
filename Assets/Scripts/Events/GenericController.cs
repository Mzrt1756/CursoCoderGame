using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GenericController : MonoBehaviour
{
    public event Action<float> OnMoveInput;
    public event Action OnJump;
    public event Action<float> OnRotate;

    [SerializeField] private GenericModel m_model;

    private void Awake()
    {
        m_model.GetControllerRef(this);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }

        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        OnMoveInput?.Invoke(l_vertical);
        OnRotate?.Invoke(l_horizontal);
    }
}
