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
        gameObject.transform.LookAt(waypoint.transform, cam.transform.up);
        
    }
 
}
