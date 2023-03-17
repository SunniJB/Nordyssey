using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfClicked : MonoBehaviour
{
    Swipe swipe;
    private void OnMouseDown()
    {
        swipe.moveUp = true;
    }
}
