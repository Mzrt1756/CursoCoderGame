using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*private PlayerController _player;
    public bool IsPaused { get; private set; }
    public MainCanvas mainCanvas { get; private set; }

   public PlayerController Player
    {
        get
        {
            if (_player == null) _player = FindObjectOfType<PlayerController>();
            return _player;
        }
    }*/
    public static GameManager instance;

    //Player
    public PlayerController player;
    public float _maxHealth = 200f;
    public float _remainingHealth;
    public float _maxMana = 200f;
    public float _remainingMana;

    //Scene Manager
    private SceneManager _sceneManager;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        _sceneManager = new SceneManager();
    }

    public void SavePlayerState(float remainingHealth, float remainingMana)
    {
        _remainingHealth = remainingHealth;
        _remainingMana = remainingMana;
    }

    public void GetPlayerState()
    {
        _remainingHealth = 0;
        _remainingMana = 0;
    }

    public void ObtainPlayerReference (PlayerController player)
    {
        this.player = player;
    }
}
