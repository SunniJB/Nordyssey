using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCanvas : MonoBehaviour
{
        public GameObject help1, help2, help3;
        public LocationListScript locationListScript;


        public void activateHelp1()
        {
        help1.SetActive(true);
        }
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
            help1.SetActive(false);
            help2.SetActive(false);
            help3.SetActive(false);
        }   
}

