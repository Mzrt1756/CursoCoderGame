using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    private PlayerController playerController;
    GameObject gameOverCanvas;

    private void OnEnable()
    {
        playerController.onPlayerDeath += DisplayGameOver;
    }

    private void OnDisable()
    {
        playerController.onPlayerDeath -= DisplayGameOver;
    }

    void DisplayGameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
}
