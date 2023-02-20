using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private AudioClip closeSound;
    public void CloseGame()
    {
        AudioManager.Instance.PlaySoundClose(closeSound);
        Application.Quit();
        Debug.Log("Cerrar");
    }
}
