using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{

    public arrowPointToPoint arrow;
    public enum destinations
    {
        Hovedbygg_Main_Building = 0,
        Nylåna = 1,
        Nordlåna = 2

    }
    //public destinations choice;

    private Vector3[] coordinates = new Vector3[] {
        new Vector3(-21.3f, 0f, 85.9f), // 0
        new Vector3(31.3f, 0f, 4.1f), // 1
        new Vector3(200f, 0f, 53f) // 2
    };


    // The destination waypoint is moved to the Vector3 location when an entry is selected
    public void SwitchWaypoint(int de)
    {
        arrow.waypoint.transform.position = coordinates[de];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
