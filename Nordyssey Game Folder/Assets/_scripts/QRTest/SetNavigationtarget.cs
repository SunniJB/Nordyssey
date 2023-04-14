using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationtarget : MonoBehaviour
{
    //[SerializeField] Dropdown navigationtargetDropdown;
    //[SerializeField] List<Target> navigationTargetObjects = new List<Target>();

    public NavMeshPath path; //current calculated path
    public LineRenderer line; //linerenderer to display path
    private Vector3 targetPosition = Vector3.zero; //Current target position
    public Transform playerCamera;
    
    public ShowMessages sM;

    public bool lineToggle = true;

    //public Text debugLogText;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    private void Update()
    {
        if (lineToggle && targetPosition!= Vector3.zero) 
        {
            NavMesh.CalculatePath(playerCamera.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            if (path.corners.Length <= 2 && path.status == NavMeshPathStatus.PathComplete)
            {
                DestinationReached();
            }
            //Debug.Log("Path was calculated, there are " + path.corners.Length + " corners.");
        }
    }

    public void SetCurrentNavigationTarget(Transform targetDestination)
    {
        targetPosition = targetDestination.transform.position;
        ToggleVisibility(false);
        /*string selectedText = navigationtargetDropdown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null) 
        {
            targetPosition = currentTarget.positionObject.transform.position;
            debugLogText.text = ("Target position is now " + targetPosition);
        }*/
    }

    private void DestinationReached()
    {
        targetPosition = Vector3.zero;
        line.enabled = lineToggle = false;
        sM.ShowMessage("Destination Reached! :D", 2f);
    }

    public void ToggleVisibility(bool t)
    {
        //Debug.Log("Line visibility was set to " + lineToggle);
        lineToggle = t;
        line.enabled = lineToggle;
    }
}
