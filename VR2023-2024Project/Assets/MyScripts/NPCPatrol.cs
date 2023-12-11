using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public Transform[] targets;
    int targetIndex;
    NavMeshAgent agent;
    public Animator animator;
    float timer;
    float waitTime;
    float waitTimeMin = 6f;
    float waitTimeMax = 7f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        timer = 0;

        targetIndex = -1;
        GoNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance && !agent.pathPending)
        {
            animator.SetBool("Walking", false);

            timer = timer + Time.deltaTime;

            if (timer >= waitTime)
            {
                GoNext();
            }
        }

    }

    void GoNext()
    {
        timer = 0;

        waitTime = Random.Range(waitTimeMin, waitTimeMax);

        //i
        targetIndex = (targetIndex + 1) % targets.Length;

        //animation
        animator.SetBool("Walking", true);

        agent.SetDestination(targets[targetIndex].position);

    }
}
