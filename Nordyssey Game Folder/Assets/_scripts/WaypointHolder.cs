using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHolder : MonoBehaviour
{
    public Transform waypoint;
    private DestinationManager dManager;

    private void Start()
    {
        dManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<DestinationManager>();
    }
    
    public void SetDestination()
    {
        dManager.SwitchWaypoint(waypoint);
    }
}
