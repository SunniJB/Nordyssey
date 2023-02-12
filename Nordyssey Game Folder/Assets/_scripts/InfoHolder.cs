using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour
{
    public int des;
    //public string tex;
    public DestinationManager dm;

    public void sendInfo()
    {
        dm.SwitchWaypoint(des);
    }
}
