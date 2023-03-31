using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldStayUp : MonoBehaviour
{
    public void OnInput()
    {
        Debug.Log("Input is happening");
        if (gameObject.GetComponent<InputField>().text != null)
        {
            Debug.Log("Input field is not empty");
        }
        else if (gameObject.GetComponent<InputField>().text == null)
        {
            Debug.Log("Input field is empty");
        }
    }
}
