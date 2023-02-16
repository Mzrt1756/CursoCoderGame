using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
