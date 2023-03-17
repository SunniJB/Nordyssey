using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMinimap : MonoBehaviour
{

    public Transform minimap;
    public Transform arCamera;
    public Image miniIcon;

    private float mX, mY;
    public float scaleCompensationX = 1f, scaleCompensationY = 1f;
    public float scaleCompensationLineX = 1f, scaleCompensationLineY = 1f;
    //private Transform[] linePoints;// = new Transform[50];


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("UpdateLineRender", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        mX = arCamera.position.z;
        mY = -arCamera.position.x;

        Vector3 offset = new Vector3((mX * scaleCompensationX) - 565f, (mY * scaleCompensationY) + 577f, 0f);
        minimap.GetComponent<RectTransform>().anchoredPosition = offset;
    }

    private void UpdateLineRender()
    {
        GameObject[] linePoints = GameObject.FindGameObjectsWithTag("linePoint");
        foreach (GameObject obj in linePoints)
        {
            float objX = -obj.transform.position.z;
            float objY = obj.transform.position.x;
            Vector3 offset = new Vector3((objX * scaleCompensationLineX), (objY * scaleCompensationLineY), 0f);

            Image point = GameObject.Instantiate(miniIcon, Vector3.zero, Quaternion.identity);
            point.color = Color.blue;
            point.transform.parent = minimap.transform;
            point.rectTransform.anchorMin = new Vector2(0.6883362f, 0.2186585f);
            point.rectTransform.anchorMax = new Vector2(0.6883362f, 0.2186585f);
            point.rectTransform.anchoredPosition = offset;
            
        }
    }
}
