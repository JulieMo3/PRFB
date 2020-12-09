using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer2 : MonoBehaviour
{

    bool patrolWaiting = true;

    [SerializeField]
    float totalWaitTime;

    [SerializeField]
    float switchProbability = 0.2f;

    [SerializeField]
    public List<WayPoint> patrolPoints;
    

    UnityEngine.AI.NavMeshAgent navMesh;

    int currentPatrolIndex;

    bool travelling;

    bool waiting = false;

    bool patrolForward;

    float waitTimer;

    public bool anotherWait;


    // Start is called before the first frame update
    void Start()
    {
        navMesh = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(patrolPoints != null && patrolPoints.Count >= 0)
        {
            currentPatrolIndex = 0;
            SetDestination();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
        if (travelling && navMesh.remainingDistance <= 1.0f)
        {
            travelling = false;
            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (waiting)
        {
            //Debug.Log(waitTimer);
            waitTimer += Time.deltaTime;
            if(anotherWait == true)
            {
                if (waitTimer >= totalWaitTime)
                {
                    waiting = false;
                    ChangePatrolPoint();
                    SetDestination();
                }
            }
        }
    }

    private void ChangePatrolPoint()
    {
        currentPatrolIndex = patrolPoints.Count - 1;
        /*
        //Debug.Log("Travelling :" + travelling);
        if (UnityEngine.Random.Range(0f,1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }
        if (patrolForward)
        {
        
        }
        else
        {
            if(--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count-1;
            }
        }
        */

    }

    private void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMesh.SetDestination(targetVector);
            travelling = true;
            anotherWait = false;
        }
    }
}
