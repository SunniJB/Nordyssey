using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

public class HelpCanvas : MonoBehaviour
{
    [Header("English screens")]
    public GameObject engHelp1;
    public GameObject engHelp2;
    public GameObject engHelp3;
    public GameObject engHelpBg;

    [Header("Norwegian screens")]
    public GameObject noHelp1;
    public GameObject noHelp2;
    public GameObject noHelp3;
    public GameObject noHelpBg;

    [Header("Spanish screens")]
    public GameObject spaHelp1; 
    public GameObject spaHelp2; 
    public GameObject spaHelp3; 
    public GameObject spaHelpBg;

    [Header("Misc")]
    public GameObject languageSettings;
    public LocationListScript locationListScript;
    public DestinationManager destinationManager;
    public bool languageCanvasIsActivated;
    public GameObject bookmarkButton;

    private int IsFirst;
    /// <summary>
    ///  0 is English, 1 is Norwegian, 2 is Spanish 
    /// </summary>
    public void activateHelp1()
    {
        bookmarkButton.SetActive(false);
        if (destinationManager.chosenLanguage == DestinationManager.languages.english)
        {
            engHelpBg.SetActive(true);
            engHelp1.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.norwegian)
        {
            noHelpBg.SetActive(true);
            noHelp1.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.spanish)
        {
            spaHelpBg.SetActive(true);
            spaHelp1.SetActive(true);
        }

    }
    public void activateHelp2()
    {
        if (destinationManager.chosenLanguage == DestinationManager.languages.english)
        {
            engHelp1.SetActive(false);
            engHelpBg.SetActive(true);
            engHelp2.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.norwegian)
        {
            noHelp1.SetActive(false);
            noHelpBg.SetActive(true);
            noHelp2.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.spanish)
        {
            spaHelp1.SetActive(false);
            spaHelpBg.SetActive(true);
            spaHelp2.SetActive(true);
        }
    }

    public void activateHelp3()
    {
        if (destinationManager.chosenLanguage == DestinationManager.languages.english)
        {
            engHelp1.SetActive(false);
            engHelp2.SetActive(false);
            engHelpBg.SetActive(true);
            engHelp3.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.norwegian)
        {
            noHelp1.SetActive(false);
            noHelp2.SetActive(false);
            noHelpBg.SetActive(true);
            noHelp3.SetActive(true);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.spanish)
        {
            spaHelp1.SetActive(false);
            spaHelp2.SetActive(false);
            spaHelpBg.SetActive(true);
            spaHelp3.SetActive(true);
        }
    }

    public void closeHelpCanvas()
    {
        bookmarkButton.SetActive(true);
        if (destinationManager.chosenLanguage == DestinationManager.languages.english)
        {
            engHelp1.SetActive(false);
            engHelp2.SetActive(false);
            engHelp3.SetActive(false);
            engHelpBg.SetActive(false);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.norwegian)
        {
            noHelp1.SetActive(false);
            noHelp2.SetActive(false);
            noHelp3.SetActive(false);
            noHelpBg.SetActive(false);
        }
        if (destinationManager.chosenLanguage == DestinationManager.languages.spanish)
        {
            spaHelp1.SetActive(false);
            spaHelp2.SetActive(false);
            spaHelp3.SetActive(false);
            spaHelpBg.SetActive(false);
        }
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

