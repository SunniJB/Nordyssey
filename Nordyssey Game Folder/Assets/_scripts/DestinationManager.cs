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
        "Nordlåna", // 1
        "Nylåna" // 2
        //"Servicetorg", // 3
        //"Bibliotek lager / Library storage", // 4
        //"Kopirom / Copier room", // 5
        //"4.161", // 6
        //"4.192", // 7
        //"4.186", // 8
        //"1.111", // 9
        //"1.112", // 10
        //"1.113", // 11
        //"1.114", // 12
        //"1.115", // 13
        //"1.116", // 14
        //"1.117", // 15
        //"1.118", // 16
        //"1.119", // 17
        //"4.261", // 18
        //"Stille lesesal / Quiet reading-room", // 19
        //"1.221", // 20
        //"Grupperom 1 / Group room 1", // 21
        //"Grupperom 2 / Group room 2", // 22
        //"Grupperom 3 / Group room 3", // 23
        //"Grupperom 4 / Group room 4", // 24
        //"Møterom 2 / Meeting room 2", // 25
        //"1.120", // 26
        //"",
        //"",
        //"",
    };
    //public destinations choice;

    private Vector3[] destinationCoordinates = new Vector3[] {
        new Vector3(-21.3f, 0f, 85.9f), // 0
        new Vector3(200f, 0f, 53f), // 1
        new Vector3(31.3f, 0f, 4.1f) // 2
        
    };


    // The destination waypoint is moved to the Vector3 location when an entry is selected
    public void SwitchWaypoint(int de)
    {
        arrow.waypoint.transform.position = destinationCoordinates[de];
        Debug.Log(destinationNames[de]);
    }

    public void SearchList(string input)
    {
        foreach (Transform c in listContent)
        {c.gameObject.SetActive(false);}
        int id = 0;
        int idButton = 0;
        foreach (string des in destinationNames)
        {
            if (des.Contains(input, System.StringComparison.CurrentCultureIgnoreCase))
            {
                GameObject b = listContent.GetChild(idButton).gameObject;
                idButton++;
                b.SetActive(true);
                b.transform.GetChild(0).GetComponent<Text>().text = destinationNames[id];
                b.GetComponent<InfoHolder>().num = id;
            }
            id++;
        }
    }
}
