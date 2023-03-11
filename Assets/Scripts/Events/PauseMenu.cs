using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    [SerializeField] private Canvas PauseMenuCanvas;

    void OnEnable()
    {
        PlayerController.OnPauseActive += DisplayPauseMenu;
    }

    private void OnDisable()
    {
        PlayerController.OnPauseActive -= DisplayPauseMenu;

    }

    void DisplayPauseMenu()
    {
        if (PauseMenuCanvas.isActiveAndEnabled)
        {
            ResumeGame();
        }
        else
        {
            PauseMenuCanvas.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
            GameIsPaused = true;
            Debug.Log("Game is Paused" + GameIsPaused);

        }
        
    }
    public void ResumeGame()
    {
        PauseMenuCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Game is Paused" + GameIsPaused);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
