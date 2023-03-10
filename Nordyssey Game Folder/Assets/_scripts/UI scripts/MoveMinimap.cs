using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMinimap : MonoBehaviour
{

    public Transform minimap;
    public Transform arCamera;

    private float mX, mY;
    public float scaleCompensationX = 1f, scaleCompensationY = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mX = arCamera.position.z;
        mY = -arCamera.position.x;

        Vector3 offset = new Vector3((mX * scaleCompensationX) - 565f, (mY * scaleCompensationY) + 577f, 0f);
        minimap.GetComponent<RectTransform>().anchoredPosition = offset;
    }
}
