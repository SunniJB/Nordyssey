using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldStayUp : MonoBehaviour
{
    public Animator groupAnimator;

    private void Start()
    {
        groupAnimator = GameObject.Find("Group").GetComponent<Animator>();
    }
    public void OnInput()
    {
        if (gameObject.GetComponent<InputField>().text != null)
        {
            groupAnimator.SetBool("move", true);
        }
        else if (gameObject.GetComponent<InputField>().text == null)
        {
            groupAnimator.SetBool("move", false);
        }
    }
}