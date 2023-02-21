using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbieSpawner : MonoBehaviour
{
    [SerializeField] private RobbieTDAController[] m_robbiePrefabs;
    [SerializeField] private Transform[] m_robbieWaypoints;
    [SerializeField] private int m_amountToInstantiate;
    /*[SerializeField] private float m_spawnTime;
    private float m_currentSpawnTime;*/

    private void Awake()
    {
        for(int i = 0; i< m_amountToInstantiate; i++)
        {
            SpawnRobbie(i);
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

    private void SpawnRobbie(int p_index)
    {
        var l_spawnPosition = GetRandomWaypoint().position;
        //var l_chosenRobbie = ChooseRobbie();
        var l_chosenRobbie = m_robbiePrefabs[p_index];
        var l_currRobbie = Instantiate(l_chosenRobbie, l_spawnPosition, Quaternion.identity);
        l_currRobbie.ReceiveWaypoints(m_robbieWaypoints);
        l_currRobbie.Init();
    }
    private RobbieTDAController ChooseRobbie()
    {
        var l_chosenRobbie = Random.Range(0, m_robbiePrefabs.Length);
        return m_robbiePrefabs[l_chosenRobbie];
    }

    private Transform GetRandomWaypoint()
    {
        var l_chosenWaypoint = Random.Range(0, m_robbieWaypoints.Length);
        return m_robbieWaypoints[l_chosenWaypoint];
    }

}
