using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRCode_Not_Scanned : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QrCodeSearch;
    void Start()
    {
        Invoke("QrScann", 10);
    }

    // Update is called once per frame
    public void QrScann()
    {
        
        QrCodeSearch.SetActive(true);
    }
}
