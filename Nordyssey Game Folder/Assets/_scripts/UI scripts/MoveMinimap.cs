using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMinimap : MonoBehaviour
{

    public Transform minimap;
    public Transform arCamera;
    public Image miniIcon, uiLine;


    private float mX, mY;
    public float scaleCompensationX = 1f, scaleCompensationY = 1f;
    public float scaleCompensationLineX = 1f, scaleCompensationLineY = 1f;
    private GameObject[] linePoints = new GameObject[50];
    private GameObject[] lineLines = new GameObject[50];


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

    public void UpdateLineRender(Vector3[] corners)
    {
        for (int j = 0; j < linePoints.Length -1; j++)
        {
            if (linePoints[j] != null)
            {
                GameObject.Destroy(linePoints[j]);
                linePoints[j] = null;  
            }
            if (lineLines[j] != null)
            {
                GameObject.Destroy(lineLines[j]);
                lineLines[j] = null;
            }
        } // Clear away old linepoints

        //GameObject[] linePoints = GameObject.FindGameObjectsWithTag("linePoint");
        Vector3[] mapPositions = new Vector3[corners.Length];
        for (int i = 0; i < corners.Length -1; i++)
        {
            float objX = -corners[i].z;
            float objY = corners[i].x;
            Vector3 offset = new Vector3((objX * scaleCompensationLineX), (objY * scaleCompensationLineY), 0f);

            Image point = GameObject.Instantiate(miniIcon, Vector3.zero, Quaternion.identity);
            point.color = new Color(0f, 0f, 1f, 0f);
            point.transform.SetParent(minimap.transform);
            point.rectTransform.anchorMin = new Vector2(0.6883362f, 0.2186585f);
            point.rectTransform.anchorMax = new Vector2(0.6883362f, 0.2186585f);
            point.rectTransform.anchoredPosition = offset;
            linePoints[i] = point.gameObject;
            mapPositions[i] = point.rectTransform.anchoredPosition3D;
        }

        for (int g = 0; g < mapPositions.Length -2; g++)
        {
            Vector3 offset = new Vector3((mapPositions[g].x + mapPositions[g+1].x) / 2, (mapPositions[g].y + mapPositions[g+1].y) / 2, 0f);
            Image line = Image.Instantiate(uiLine, Vector3.zero, Quaternion.identity);
            line.color = Color.blue;
            line.transform.SetParent(minimap.transform);
            line.rectTransform.anchorMin = new Vector2(0.6883362f, 0.2186585f);
            line.rectTransform.anchorMax = new Vector2(0.6883362f, 0.2186585f);
            line.rectTransform.anchoredPosition = offset;
            line.transform.localScale = 
                new Vector3(Vector2.Distance(linePoints[g].GetComponent<RectTransform>().anchoredPosition, 
                linePoints[g+1].GetComponent<RectTransform>().anchoredPosition) / 100, 0.5f, 1f);
            Vector3 dif = linePoints[g+1].GetComponent<RectTransform>().anchoredPosition - linePoints[g].GetComponent<RectTransform>().anchoredPosition;
            line.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));

            lineLines[g] = line.gameObject;
        }
    }
}
