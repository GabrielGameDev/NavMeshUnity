using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    NavMeshAgent agent;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1)
		{
            if (index >= waypoints.Length - 1)
                index = 0;
            else
                index++;

            agent.SetDestination(waypoints[index].position);
		}
    }
}
