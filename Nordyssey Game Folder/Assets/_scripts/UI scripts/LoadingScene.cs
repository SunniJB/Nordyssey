using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    float time, second;
    [SerializeField]
    public Image Fillbar;

    void Start()
    {
        second = 2;
        Invoke("LoadGame", 5f);

    }

    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            Fillbar.fillAmount = time / second;
        }
    }


    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
