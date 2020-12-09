using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] Transform  destination;
    UnityEngine.AI.NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetDestination();

    }

    private void SetDestination()
    {
        if(destination != null)
        {
                Vector3 targetVector = destination.transform.position;
                navMesh.SetDestination(targetVector);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
