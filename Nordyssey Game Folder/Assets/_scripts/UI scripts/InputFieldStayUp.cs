using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldStayUp : MonoBehaviour
{
    public AnimatedSwipe animatedSwipe;
    public Text inputFieldText;

    private void Start()
    {
        animatedSwipe = GameObject.Find("Group").GetComponent<AnimatedSwipe>();
    }
    public void OnInput()
    {
        if (inputFieldText.text.Length != 0)
        {
            animatedSwipe.MoveCanvas();
            Debug.Log("There is text here");
        }
        else if (inputFieldText.text.Length == 0)
        {
            animatedSwipe.MoveCanvas();
            Debug.Log("there is no text here");
        }
    }
}
