using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationListScript : MonoBehaviour
{
    public GameObject buildingList, roomList;
    
    public void activeBuildingList()
    {
        buildingList.SetActive(true);
        roomList.SetActive(false);
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
