using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private MainCharacterData rebeccaData;

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
    //public int _maxHealth = 200;
    public int _remainingHealth;
    //public int _maxMana = 200;
    public int _remainingMana;

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

    public void SavePlayerState(int remainingHealth, int remainingMana)
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
