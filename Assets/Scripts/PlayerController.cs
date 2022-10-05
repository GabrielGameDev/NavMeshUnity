using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public int mouseButton;
    NavMeshAgent agent;
    Camera myCam;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(mouseButton))
		{
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
			{
                agent.SetDestination(hit.point);
			}
		}

        print(agent.velocity.magnitude);
        animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
        animator.SetBool("Grounded", !agent.isOnOffMeshLink);
    }
}
