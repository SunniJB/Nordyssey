using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookmarkController : MonoBehaviour
{
    private string[] bookmarks = new string[20];
    public DestinationManager dManager;
    public Transform roomWaypointsRoot;
    public ShowMessages sM;
    public Transform bookmarkButtonsParent;
    private bool cActive;

    public GameObject searchCanvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            bookmarks[i] = PlayerPrefs.GetString("BM"+i, "Not Set");
            bookmarkButtonsParent.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = bookmarks[i];
        }

        cActive = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void FindBookmark(int j)
    {
        foreach (Transform building in roomWaypointsRoot)
        {

            foreach (Transform room in building)
            {
                
                if (room.name == bookmarks[j])
                {
                    dManager.SwitchWaypoint(room);
                    return;
                }
            }
        }

        sM.ShowMessage("Bookmarked room could not be found! This bookmark may need to be deleted and re-set.", 5f, Color.red);
    }

    public void AddBookmark()
    {
        if (dManager.chosenTarget == null)
        {
            sM.ShowMessage("Please choose a room as a destination first.", 2f, Color.white);
            return;
        }
        string s = dManager.chosenTarget.name;
        for (int g = 0; g < 20; g++)
        {
            if (bookmarks[g] == "Not Set")
            {
                bookmarks[g] = s;
                PlayerPrefs.SetString("BM"+g, s);
                PlayerPrefs.Save();
                bookmarkButtonsParent.GetChild(g).GetChild(0).GetComponent<TMP_Text>().text = bookmarks[g];
                return;
            }
        }

        sM.ShowMessage("Bookmark list is full! Remove an old bookmark!", 2f, Color.yellow);
    }

    public void RemoveBookmark(int h)
    {
        bookmarks[h] = "Not Set";
        PlayerPrefs.DeleteKey("BM"+h);
        PlayerPrefs.Save();
        bookmarkButtonsParent.GetChild(h).GetChild(0).GetComponent<TMP_Text>().text = bookmarks[h];
    }

    public void ShowCanvas()
    {
        Debug.Log ("Button was clicked.");
        cActive = !cActive;
        transform.GetChild(0).gameObject.SetActive(cActive);
        searchCanvas.SetActive(!cActive);
    }
}
