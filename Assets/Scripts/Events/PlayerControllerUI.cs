using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_currentHealthText;
    [SerializeField] private PlayerController m_playerController;

    /*private void Start()
    {
        var l_healthController = m_playerController.GetHealthController();
        l_healthController.OnHealthChange += UpdateHealthUI;
    }
    private void UpdateHealthUI(float p_currentHealth)
    {
        m_currentHealthText.text = $"Health: {p_currentHealth}";
    }*/
}


