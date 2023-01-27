using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DestinationManager : MonoBehaviour
{

    public arrowPointToPoint arrow;
    public InputField inputField;
    public Transform listContent;


    private string[] destinationNames = new string[3]
    {
        "Hovedbygg/Main Building", // 0
        "Nylåna", // 1
        "Nordlåna" // 2

    };
    //public destinations choice;

    private Vector3[] destinationCoordinates = new Vector3[] {
        new Vector3(-21.3f, 0f, 85.9f), // 0
        new Vector3(31.3f, 0f, 4.1f), // 1
        new Vector3(200f, 0f, 53f) // 2
    };


    // The destination waypoint is moved to the Vector3 location when an entry is selected
    public void SwitchWaypoint(int de)
    {
        arrow.waypoint.transform.position = destinationCoordinates[de];
    }

    public void SearchList(string input)
    {
        foreach (Transform c in listContent)
        {c.gameObject.SetActive(false);}
        int id = 0;
        int idButton = 0;
        foreach (string des in destinationNames)
        {
            if (des.Contains(input))
            {
                GameObject b = listContent.GetChild(idButton).gameObject;
                b.SetActive(true);
                b.GetComponent<Text>().text = destinationNames[id];
                b.GetComponent<InfoHolder>().num = id;
            }
            id++;
        }
    }
}
