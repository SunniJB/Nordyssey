using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AR_GPS_Combiner : MonoBehaviour
{
    private bool constantUpdate = false;
    public GetLocationRelativeToCampus getgps;
    public GameObject scriptManager;
    private DebugTextController debugController;
    public TMP_Text constantNavText;

    // Start is called before the first frame update
    void Start()
    {
        debugController = scriptManager.GetComponent<DebugTextController>();
        getgps.orientPlayer = false;
        getgps.orientOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapLocationFindingMethod()
    {
        if (constantUpdate)
        {
            constantUpdate = false;
            getgps.orientOnce = false;
            constantNavText.text = "Constant Navigation: OFF";
            // Start running AR based guidance
        }
        else
        {
            constantUpdate = true;
            getgps.orientOnce = true;
            constantNavText.text = "Constant Navigation: ON";
            // Stop running AR based guidance
        }
    }
}
