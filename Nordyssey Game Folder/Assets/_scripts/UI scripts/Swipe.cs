using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject searchMenu;

    public HelpCanvas helpCanvas;

    public float x1;
    public float x2;

    public float move = 0;

    LocationListScript locationListScript;

    //Start is called before the first frame update
    void Start()
    {

    }
    public bool moveUp, moveDown;
    private bool up = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            x1 = Input.mousePosition.y;
        }


        if (Input.GetMouseButtonUp(0))
        {
            x2 = Input.mousePosition.y;
            Debug.Log(searchMenu.transform.position.y);

            if (x1 < x2 && searchMenu.transform.position.y < Screen.height / 1.2)
            {
                moveUp = true;
                Debug.Log("move = 1f;");
                //searchMenu.transform.Translate(Vector2.down * (1000 * Time.deltaTime));
            }
            else if (x1 > x2 && searchMenu.transform.position.y > Screen.height / 2)
            {
                moveDown = true;
                Debug.Log("move = 2f;");
                //searchMenu.transform.Translate(Vector2.up * (1000 * Time.deltaTime));
            }
        }

        if (moveDown == true && helpCanvas.help1.activeSelf == false && helpCanvas.help2.activeSelf == false && helpCanvas.help3.activeSelf == false)
        {
            //Debug.Log("Move down was activated");
            searchMenu.transform.Translate(Vector2.down * (1000 * Time.deltaTime));
            if (searchMenu.transform.position.y < Screen.height / 2)
            {
                moveDown = false;
                up = false;
            }
        }
        else if (moveUp == true && helpCanvas.help1.activeSelf == false && helpCanvas.help2.activeSelf == false && helpCanvas.help3.activeSelf == false)
        {
            searchMenu.transform.Translate(Vector2.up * (1000 * Time.deltaTime));
            if (searchMenu.transform.position.y > Screen.height / 1.2)
            {
                moveUp = false;
                up = true;
            }
        }
        
    }

    public void MoveDown()
    {
        if (helpCanvas.help1.activeSelf == false && helpCanvas.help2.activeSelf == false && helpCanvas.help3.activeSelf == false)
        {
            moveDown = true;
        }
        
    }

    public void MoveUp()
    {
        if (helpCanvas.help1.activeSelf == false && helpCanvas.help2.activeSelf == false && helpCanvas.help3.activeSelf == false)
        {
            moveUp = true;
        }
    }

    public void ToggleUpDown()
    {
        if (helpCanvas.help1.activeSelf == false && helpCanvas.help2.activeSelf == false && helpCanvas.help3.activeSelf == false)
        {
            if (up == false)
            { moveUp = true; }
            else
            { moveDown = true; }
        }
    }

    //public void PositionReset()
    //{
    //    searchMenu.transform.position = new Vector3(searchMenu.transform.position.x, 962f, searchMenu.transform.position.z);
    //}
}