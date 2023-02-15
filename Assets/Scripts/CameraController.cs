using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    [SerializeField] private CinemachineVirtualCamera enemyCamera;
    [SerializeField] private CinemachineVirtualCamera dollCamera;
    [SerializeField] private CinemachineVirtualCamera room1Camera;
    [SerializeField] private CinemachineVirtualCamera room2Camera;
    /*[SerializeField] private Transform characterToFollow;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 _offset;*/
    // Start is called before the first frame update

    private void Awake()
    {
        /*_offset = transform.position;*/
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TurnOnCamera(fpsCamera, enemyCamera, dollCamera, room1Camera, room2Camera);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TurnOnCamera(enemyCamera, fpsCamera, dollCamera, room1Camera, room2Camera);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            TurnOnCamera(dollCamera, fpsCamera, enemyCamera, room1Camera, room2Camera);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            TurnOnCamera(room1Camera, fpsCamera, enemyCamera, dollCamera, room2Camera);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            TurnOnCamera(room2Camera, fpsCamera, enemyCamera, dollCamera, room1Camera);
        }
    }

    /*private void LateUpdate()
    {
        transform.position = characterToFollow.position + _offset;
    }*/
    private void TurnOnCamera(CinemachineVirtualCamera camToTurnOn, CinemachineVirtualCamera otherCamera1, CinemachineVirtualCamera otherCamera2, CinemachineVirtualCamera otherCamera3, CinemachineVirtualCamera otherCamera4)
    {
        //Opcion 1: Apagar y prender el GO
        camToTurnOn.gameObject.SetActive(true);
        otherCamera1.gameObject.SetActive(false);
        otherCamera2.gameObject.SetActive(false);
        otherCamera3.gameObject.SetActive(false);
        otherCamera4.gameObject.SetActive(false);

    }
}
