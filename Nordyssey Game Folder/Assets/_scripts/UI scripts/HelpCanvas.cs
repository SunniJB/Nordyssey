using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCanvas : MonoBehaviour
{
        public GameObject help2, help3;
        public LocationListScript locationListScript;


        public void activateHelp2()
        {
        help2.SetActive(true);
        }

        public void activateHelp3()
        {
            help3.SetActive(true);
        }

        public void closeHelpCanvas()
        {
            help2.SetActive(false);
            help3.SetActive(false);
        }
}

