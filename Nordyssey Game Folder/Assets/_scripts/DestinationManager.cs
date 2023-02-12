using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DestinationManager : MonoBehaviour
{

    public arrowPointToPoint arrow;
    public InputField inputField;
    public Transform waypointsRoot;
    [Tooltip("The buttons in question are the ones you select from after writing in the input field.")]
    public Transform buttonsParent;
    //public Button button1;


    /*private string[] destinationNames = new string[27]
    {
        "Hovedbygg/Main Building", // 0
        "Nordlåna", // 1
        "Nylåna", // 2
        "Servicetorg", // 3
        "Bibliotek lager / Library storage", // 4
        "Kopirom / Copier room", // 5
        "4.161", // 6
        "4.192", // 7
        "4.186", // 8
        "1.111", // 9
        "1.112", // 10
        "1.113", // 11
        "1.114", // 12
        "1.115", // 13
        "1.116", // 14
        "1.117", // 15
        "1.118", // 16
        "1.119", // 17
        "4.261", // 18
        "Stille lesesal / Quiet reading-room", // 19
        "1.221", // 20
        "Grupperom 1 / Group room 1", // 21
        "Grupperom 2 / Group room 2", // 22
        "Grupperom 3 / Group room 3", // 23
        "Grupperom 4 / Group room 4", // 24
        "Møterom 2 / Meeting room 2", // 25
        "1.120" // 26
        //"",
        //"",
        //"",
    };*/
    //public destinations choice;

    /*private Vector3[] destinationCoordinates = new Vector3[] {
        new Vector3(-21.3f, 0f, 85.9f), // 0
        new Vector3(200f, 0f, 53f), // 1
        new Vector3(31.3f, 0f, 4.1f) // 2
        
    };*/

    public Transform[] destinations = new Transform[20];

    // The destination waypoint is moved to the Vector3 location when an entry is selected
    public void SwitchWaypoint(int des)
    {
        arrow.waypoint.transform.position = destinations[des].position;
        Debug.Log("Destination: " + destinations[des].name);
    }

    public void SearchList(string input)
    {
        // Each waypoint will have a script that only exists to store the name of the-
        // room in different languages. For now this will only be Norwegian and English.
        // The script retrieves a reference to every single waypoint in the scene-
        // and does a comparison on their language appropriate name with the-
        // input from the input field.
        // All the necessary information is stored in the Main scene and can be easily organized.
        // Waypoints will be organized with a root empty object, with each building as a child.
        // Their direct children will be all the rooms in those buildings. So that the hiearchy is only three levels deep.

        
        int desId = 0;

        
        foreach (Transform building in waypointsRoot)
        {
            //int idButton = 0; 

            foreach (Transform room in building)
            {
                if (room.name.Contains(input, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    if (desId > destinations.Length -1)
                    {return;} // For now we will only be able to display a limited number of options
                    destinations[desId] = room;
                    buttonsParent.GetChild(desId).GetChild(0).GetComponent<TMP_Text>().text = room.name;
                    desId++;
                    //idButton++;
                    //b.SetActive(true);
                    //b.transform.GetChild(0).GetComponent<TMP_Text>().text = destinations[id].name;
                }
            }
        }
    }
}
