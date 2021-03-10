using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent; //navMeshAgent variable
    public Transform[] waypoints; //variable for waypoint

    int m_CurrentWaypointIndex; //current waypoint variable

    // Start is called before the first frame update
    void Start()
    {
        //set  initial destination of navMeshAgent
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //if navMeshAgent is at destination (remaining distance < stopping distance)
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //update current waypoint index
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //set destination
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
