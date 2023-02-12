using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugTextController : MonoBehaviour
{

    public TMP_Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        debugText.gameObject.SetActive(false);
    }

    public void ShowDebugWarning(string input)
    {
        StopAllCoroutines();
        StartCoroutine("ShowWarning", input);
    }

    public void ShowDebugError(string input)
    {
        StopAllCoroutines();
        StartCoroutine("ShowError", input);
    }

    private IEnumerator ShowWarning(string input)
    {
        debugText.gameObject.SetActive(true);
        debugText.text = input;
        debugText.color = Color.yellow;
        yield return new WaitForSeconds(5f);
        debugText.gameObject.SetActive(false);
    }

    private IEnumerator ShowError(string input)
    {
        debugText.gameObject.SetActive(true);
        debugText.text = input;
        debugText.color = Color.red;
        yield return new WaitForSeconds(5f);
        debugText.gameObject.SetActive(false);
    }
}
