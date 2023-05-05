using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPointToPoint : MonoBehaviour
{
    public GameObject waypoint;
    public Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    public void Update()
    {
        waypoint = GameObject.FindGameObjectWithTag("waypoint");
        Vector3 pointDir = new Vector3(waypoint.transform.position.x, gameObject.transform.position.y, waypoint.transform.position.z);
        gameObject.transform.LookAt(pointDir, Vector3.up);
        
    }
 
}
