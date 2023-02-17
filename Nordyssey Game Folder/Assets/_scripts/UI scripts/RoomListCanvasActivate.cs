using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListCanvasActivate : MonoBehaviour
{
    public GameObject MainBuildingList, NordlanaList, NylanaList;

    public void activeMainBuildingList()
    {
        MainBuildingList.SetActive(true);
    }

    public void activeNordlanaList()
    {
        NordlanaList.SetActive(true);
    }

    public void activeNylanaList()
    {
        NylanaList.SetActive(true);
    }
}
