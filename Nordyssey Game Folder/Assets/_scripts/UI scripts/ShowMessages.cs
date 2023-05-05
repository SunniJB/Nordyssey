using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowMessages : MonoBehaviour
{

    public Image messageBackground;
    public TMP_Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        HideMessage();
    }

    public void ShowMessage(string message, float duration, Color c)
    {
        messageBackground.gameObject.SetActive(true);
        messageText.text = message;
        messageText.color = c;
        Invoke ("HideMessage", duration);
    }

    private void HideMessage()
    {
        messageBackground.gameObject.SetActive(false);
    }
}
