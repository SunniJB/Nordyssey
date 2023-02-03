using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationListScript : MonoBehaviour
{
    public GameObject buildingList, roomList;
    public GameObject searchCanvas;

    
    public void activeBuildingList()
    {
        buildingList.SetActive(true);
        roomList.SetActive(false);
        searchCanvas.GetComponent<Swipe>().moveDown = true;
    }

    public void activeRoomList()
    {
        roomList.SetActive(true);
    }
    public void backToMainScreen()
    {
        buildingList.SetActive(false);
        roomList.SetActive(false);
        
    }
}
