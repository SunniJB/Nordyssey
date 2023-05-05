using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DestinationManager : MonoBehaviour
{

    //public arrowPointToPoint arrow;
    // This is done in SetNavigationtarget now.
    public InputField inputField;
    public Transform waypointsRoot;
    [Tooltip("The buttons in question are the ones you select from after writing in the input field.")]
    public Transform buttonsParent;

    public Transform[] destinations = new Transform[20];
    public DrawLineOnMinimap drawLineOnMinimap;
    public SetNavigationtarget pathfindingLineController;

    public GameObject animationGroup;

    public ShowMessages sM;

    public enum languages {
        english,
        norwegian,
        spanish
    }
    public languages chosenLanguage = languages.english;
    public Transform chosenTarget;
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

    private void Start()
    {
        foreach (Transform button in buttonsParent)
        {button.gameObject.SetActive(false);}
        // chosenLanguage = languages.norwegian;
    }

    public void ChooseLanguage(int i)
    {
        switch (i)
        {
            case 0:
                chosenLanguage = languages.english; break;
            case 1:
                chosenLanguage = languages.norwegian; break;
            case 2:
                chosenLanguage = languages.spanish; break;
            case > 2:
                Debug.LogError("Integer out of range!");
                break;
        }
    }

    // The destination waypoint is moved to the Vector3 location when an entry is selected
    public void SwitchWaypoint(int des)
    {
        //arrow.waypoint.transform.position = destinations[des].position;
        //Debug.Log("Destination: " + destinations[des].name);
        drawLineOnMinimap.SetTarget(destinations[des].position);
        pathfindingLineController.SetCurrentNavigationTarget(destinations[des]);
        pathfindingLineController.ToggleVisibility(true);
        sM.ShowMessage("Current Destination: " + destinations[des].name, 2f, Color.white);
        chosenTarget = destinations[des];
    }

    public void SwitchWaypoint(Transform tran)
    {
        //arrow.waypoint.transform.position = tran.position;
        //Debug.Log("Destination: " + tran.name);
        drawLineOnMinimap.SetTarget(tran.position);
        pathfindingLineController.SetCurrentNavigationTarget(tran);
        pathfindingLineController.ToggleVisibility(true);
        sM.ShowMessage("Current Destination: " + tran.name, 2f, Color.white);
        chosenTarget = tran;
    }

    public void SearchList(string input)
    {
        // Each waypoint will have a script that only exists to store the name of the-
        // room in different languages. For now this will only be Norwegian, English and Spanish.
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
                if (room.TryGetComponent<Alt_Languages>(out Alt_Languages altLang))
                {
                    string comparisonName = 
                    chosenLanguage switch
                    {
                        languages.english => altLang.english,
                        languages.norwegian => altLang.norwegian,
                        languages.spanish => altLang.spanish
                    };

                    if (comparisonName.Contains(input, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (desId > destinations.Length -1 || desId > buttonsParent.childCount -1)
                        {return;} // For now we will only be able to display a limited number of options

                        destinations[desId] = room;
                        GameObject button = buttonsParent.GetChild(desId).gameObject;
                        button.SetActive(true);
                        button.transform.GetChild(0).GetComponent<TMP_Text>().text = comparisonName;

                        // If you are Norwegian, you probably want to know the english name
                        // And if you are a different nationality, you probably want to know the norwegian name.
                        button.transform.GetChild(1).gameObject.SetActive(true);
                        button.transform.GetChild(1).GetComponent<TMP_Text>().text = chosenLanguage switch
                        {
                            languages.english => altLang.norwegian,
                            languages.norwegian => altLang.english,
                            languages.spanish => altLang.norwegian
                        };
                        desId++;  
                    }
                    
                }
                else
                {
                    if (room.name.Contains(input, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (desId > destinations.Length -1 || desId > buttonsParent.childCount -1)
                        {return;} // For now we will only be able to display a limited number of options

                        destinations[desId] = room;
                        GameObject button = buttonsParent.GetChild(desId).gameObject;
                        button.SetActive(true);
                        button.transform.GetChild(0).GetComponent<TMP_Text>().text = room.name;

                        // There is no other name for this room, so displaying the secondary text is not necessary.
                        button.transform.GetChild(1).gameObject.SetActive(false); 
                        desId++;
                    }
                    
                }
            }
        }

        for (int i = desId; i < buttonsParent.childCount -1; i++)
        {
            // Turn off the extra buttons we don't need.
            buttonsParent.GetChild(i).gameObject.SetActive(false);
        }
    }
}
