using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddPointScript : MonoBehaviour
{
    public GameObject Player;
    public WayPoint WaypointSelect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Player.GetComponent<MovementPlayer2>().patrolPoints.Add(WaypointSelect);
        }
    }
}
