using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbieTDAController : Enemy
{

    [SerializeField] private RobbieData robbieData;

    //[SerializeField] private int m_startingWaypoint;
    [SerializeField] private Transform[] m_waypoints;
    //[SerializeField] private List<Transform> m_listWaypoints;

    private int m_currentWaypointIndex;

    public void ReceiveWaypoints(Transform[] p_waypoints)
    {
        m_waypoints = p_waypoints;
    }

    public void Init()
    {
        m_currentWaypointIndex = Random.Range(0, m_waypoints.Length);
    }

    private void Awake()
    {
        /*
        if (m_startingWaypoint > m_waypoints.Length-1)
        {
            m_startingWaypoint = 0;
        }
        m_currentWaypointIndex = m_startingWaypoint;*/

        /*m_currentWaypointIndex = Random.Range(0, m_waypoints.Length);*/

    }
    void Start()
    {
        /*
        var l_myNewWaypoints = new Transform[5];
        var l_myNewWaypointsList = new List<Transform>;*/
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * robbieData.speed * Time.deltaTime;
    }
    private void Patrol()
    {
        var l_currentWaypoint = m_waypoints[m_currentWaypointIndex];
        var l_currDifference = (l_currentWaypoint.position - transform.position);
        var l_direction = l_currDifference.normalized;
        Move(l_direction);
        var l_currDistance = l_currDifference.magnitude;
        if(l_currDistance <= robbieData.distanceThreshold)
        {
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        m_currentWaypointIndex++;
        if(m_currentWaypointIndex>m_waypoints.Length-1)
        {
            m_currentWaypointIndex = 0;
        }
    }
}
