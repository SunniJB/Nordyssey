using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationListScript : MonoBehaviour
{
    public GameObject buildingList, helpCanvas;
    //public GameObject searchCanvas;


    public void activeBuildingList()
    {
        buildingList.SetActive(true);
        //searchCanvas.GetComponent<Swipe>().moveDown = true;
    }

   
    public void backToMainScreen()
    {
        
        buildingList.SetActive(false);
        
    }

    public void deactiveRoomList()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("RoomList");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
    }

    public void activateHelpCanvas()
    {
        helpCanvas.SetActive(true);
    }
}
