using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DrawLineOnMinimap : MonoBehaviour
{
    //[SerializeField] Dropdown navigationtargetDropdown;
    //[SerializeField] List<Target> navigationTargetObjects = new List<Target>();

    public NavMeshPath path; //current calculated path
    //private LineRenderer line; //linerenderer to display path
    private Vector3 targetPosition = Vector3.zero; //Current target position
    private MoveMinimap moveMap;
    public Transform sessionCamera;

    public bool lineToggle = true;

    //public Text debugLogText;

    private void Start()
    {
        path = new NavMeshPath();
        //line = transform.GetComponent<LineRenderer>();
        //line.enabled = lineToggle;
        moveMap = transform.GetComponent<MoveMinimap>();
    }

    private void Update()
    {
        if (lineToggle && targetPosition!= Vector3.zero) 
        {
            NavMesh.CalculatePath(sessionCamera.transform.position, targetPosition, NavMesh.AllAreas, path);
            //line.positionCount = path.corners.Length;
            //line.SetPositions(path.corners);
            //Debug.Log("Path was calculated, there are " + path.corners.Length + " corners.");
            moveMap.UpdateLineRender(path.corners);
            if (path.corners.Length <= 2 && path.status == NavMeshPathStatus.PathComplete)
            {
                targetPosition = Vector3.zero;
                moveMap.ToggleVisibility(false);
            }
        }
    }

    public void SetTarget(Vector3 tPos)
    {
        targetPosition = tPos;
        moveMap.ToggleVisibility(true);
    }

    /*public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = navigationtargetDropdown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null) 
        {
            targetPosition = currentTarget.positionObject.transform.position;
            debugLogText.text = ("Target position is now " + targetPosition);
        }
    }

    public void ToggleVisibility()
    {
        Debug.Log("Line visibility was set to " + lineToggle);
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }*/
}
