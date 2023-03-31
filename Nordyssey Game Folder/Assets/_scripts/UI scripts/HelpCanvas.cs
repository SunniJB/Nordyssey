using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCanvas : MonoBehaviour
{
        public GameObject help1, help2, help3, helpBg;
        public LocationListScript locationListScript;


        public void activateHelp1()
        {
        helpBg.SetActive(true);
        help1.SetActive(true);
        }
        public void activateHelp2()
        {
        help1.SetActive(false);
        helpBg.SetActive(true);
        help2.SetActive(true);
        }

        public void activateHelp3()
        {
            help1.SetActive(false);
            help2.SetActive(false);
            helpBg.SetActive(true);
            help3.SetActive(true);
        }

        public void closeHelpCanvas()
        {
            help1.SetActive(false);
            help2.SetActive(false);
            help3.SetActive(false);
            helpBg.SetActive(false);
        }   
}

