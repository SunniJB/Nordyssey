using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class HelpCanvas : MonoBehaviour
{
    public GameObject help1, help2, help3, helpBg, languageSettings;
    public LocationListScript locationListScript;
    public bool languageCanvasIsActivated;

    public int IsFirst;
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

    public void activateLanguageCanvas()
    {
        languageSettings.SetActive(true);
        languageCanvasIsActivated = true;
    }

    public void closeLanguageCanvas()
    {
        if (languageCanvasIsActivated == true)
        {
            languageSettings.SetActive(false);
            languageCanvasIsActivated = false;
        }

    }

    public void FirstTimeTutorial()
    {
        IsFirst = PlayerPrefs.GetInt("IsFirst");
        if (IsFirst == 0)
        {
            //Do stuff on the first time
            activateHelp1();
            Debug.Log("first run");
            PlayerPrefs.SetInt("IsFirst", 1);
        }
        else
        {
            //Do stuff other times
            Debug.Log("welcome again!");
        }
    }
}

