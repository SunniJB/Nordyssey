using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_GPS_Combiner : MonoBehaviour
{
    private bool gps = true;
    public GetLocationRelativeToCampus getgps;
    public GameObject scriptManager;
    private DebugTextController debugController;

    // Start is called before the first frame update
    void Start()
    {
        debugController = scriptManager.GetComponent<DebugTextController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapLocationFindingMethod()
    {
        if (gps)
        {
            gps = false;
            getgps.StopLocation();
            debugController.ShowDebugWarning("AR guidance not yet integrated");
            // Start running AR based guidance
        }
        else
        {
            gps = true;
            getgps.RestartLocationFinding();
            // Stop running AR based guidance
        }
    }
}
