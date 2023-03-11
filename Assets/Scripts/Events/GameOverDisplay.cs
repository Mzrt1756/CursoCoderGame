using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private GameObject GaveOverPanel;

    void OnEnable()
    {
        PlayerController.OnPlayerDeath += DisplayGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= DisplayGameOver;
    }

    void DisplayGameOver()
    {
            GaveOverPanel.gameObject.SetActive(true);
    }
}
