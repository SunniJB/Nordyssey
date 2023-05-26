using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMinimap : MonoBehaviour
{

    public Transform minimap;
    public Transform arCamera;
    public Image miniIcon;
    public RawImage uiLine;


    private float mX, mY;
    private float scaleCompensationSmall = 7.15f;
    private float scaleCompensationBig = 10.8f;
    private float scaleCompensationLineSmall = 2.35f;


    public bool bigMap = false;

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

        Vector3 offset;

        if (!bigMap)
        {
            offset = new Vector3((mX * scaleCompensationSmall) - 592f, (mY * scaleCompensationSmall) + 584f, 0f); 
        }
        else 
        {
            offset = new Vector3((mX * scaleCompensationBig) - 904f, (mY * scaleCompensationBig) + 888f, 0f);
        }

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
            Vector3 offset = new Vector3(((objX + 12f) * scaleCompensationLineSmall), (objY * scaleCompensationLineSmall), 0f);

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
            RawImage line = RawImage.Instantiate(uiLine, Vector3.zero, Quaternion.identity);
            line.color = Color.blue;
            line.transform.SetParent(minimap.transform);
            line.rectTransform.anchorMin = new Vector2(0.6883362f, 0.2186585f);
            line.rectTransform.anchorMax = new Vector2(0.6883362f, 0.2186585f);
            line.rectTransform.anchoredPosition = offset;
            line.transform.localScale = 
                new Vector3(Vector2.Distance(linePoints[g].GetComponent<RectTransform>().anchoredPosition, 
                linePoints[g+1].GetComponent<RectTransform>().anchoredPosition) / -100, 1.5f, 1f);
            Vector3 dif = linePoints[g+1].transform.localPosition - linePoints[g].transform.localPosition;
            //line.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
            float zAngle = Vector3.SignedAngle(dif, transform.right, transform.forward);
            /*if (zAngle <= 0f)
            {
                line.rectTransform.Rotate(new Vector3(0f, 0f, zAngle - 180f));
            }
            else
            {*/
                line.rectTransform.Rotate(new Vector3(0f, 0f, -zAngle + 180f));
            //}
            

            lineLines[g] = line.gameObject;
        }
    }

    public void ResizeMinimap()
    {
        if (bigMap == false)
        {
            bigMap = true;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1200, 1200);
            minimap.localScale = new Vector3(4.5f, 4.5f, 4.5f);
        }
        else
        {
            bigMap = false;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
            minimap.localScale = new Vector3(2.95f, 2.95f, 2.95f);
        }
    }

    public void ToggleVisibility(bool toggle)
    {
        foreach (GameObject line in lineLines)
        {
            if (line != null)
                {line.SetActive(toggle);}
        }
    }
}
