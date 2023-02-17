using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject searchMenu;

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

            if (x1 < x2 && searchMenu.transform.position.y < 1761)
            {
                moveUp = true;
                Debug.Log("move = 1f;");
                //searchMenu.transform.Translate(Vector2.down * (1000 * Time.deltaTime));
            }
            else if (x1 > x2 && searchMenu.transform.position.y > 962)
            {
                moveDown = true;
                Debug.Log("move = 2f;");
                //searchMenu.transform.Translate(Vector2.up * (1000 * Time.deltaTime));
            }
        }

        if (moveDown == true)
        {
            //Debug.Log("Move down was activated");
            searchMenu.transform.Translate(Vector2.down * (1000 * Time.deltaTime));
            if (searchMenu.transform.position.y < 962)
            {
                moveDown = false;
                up = false;
            }
        }
        else if (moveUp == true)
        {
            searchMenu.transform.Translate(Vector2.up * (1000 * Time.deltaTime));
            if (searchMenu.transform.position.y > 1761)
            {
                moveUp = false;
                up = true;
            }
        }
        
    }

    public void MoveDown()
    {
        moveDown = true;
    }

    public void MoveUp()
    {
        moveUp = true;
    }

    public void ToggleUpDown()
    {
        if (up == false)
        {moveUp = true;}
        else
        {moveDown = true;}
    }

    //public void PositionReset()
    //{
    //    searchMenu.transform.position = new Vector3(searchMenu.transform.position.x, 962f, searchMenu.transform.position.z);
    //}
}