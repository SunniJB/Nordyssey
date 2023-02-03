using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationListScript : MonoBehaviour
{
    public GameObject activeCanvas;
    
    public void whenButtonClicked()
    {
        activeCanvas.SetActive(true);
    }
}
