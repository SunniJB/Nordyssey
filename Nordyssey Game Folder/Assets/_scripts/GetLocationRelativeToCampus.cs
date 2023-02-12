using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GetLocationRelativeToCampus : MonoBehaviour
{

    public Transform userObject;
    public Text displayText;
    public GameObject scriptManager;
    private DebugTextController debugController;

    private float corX, corZ, locX, locZ;
    private float orgX = 63.7538178f, orgZ = 11.3129061f;

    private void Awake()
    {
        void PermissionCallbacks_PermissionDeniedAndDontAskAgain(string permissionName)
        {
            Debug.Log($"{permissionName} PermissionDeniedAndDontAskAgain");
        }

        void PermissionCallbacks_PermissionGranted(string permissionName)
        {
            Debug.Log($"{permissionName} PermissionCallbacks_PermissionGranted");
        }

        void PermissionCallbacks_PermissionDenied(string permissionName)
        {
            Debug.Log($"{permissionName} PermissionCallbacks_PermissionDenied");
        }

        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // The user authorized use of the GPS.
        }
        else
        {
            bool useCallbacks = false;
            if (!useCallbacks)
            {
                // We do not have permission to use the GPS.
                // Ask for permission or proceed without the functionality enabled.
                Permission.RequestUserPermission(Permission.FineLocation);
            }
            else
            {
                var callbacks = new PermissionCallbacks();
                callbacks.PermissionDenied += PermissionCallbacks_PermissionDenied;
                callbacks.PermissionGranted += PermissionCallbacks_PermissionGranted;
                callbacks.PermissionDeniedAndDontAskAgain += PermissionCallbacks_PermissionDeniedAndDontAskAgain;
                Permission.RequestUserPermission(Permission.FineLocation, callbacks);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        debugController = scriptManager.GetComponent<DebugTextController>();

        StartCoroutine("FindLocation");
    }

    public void RestartLocationFinding()
    {
        if (Input.location.status == LocationServiceStatus.Stopped
        ||  Input.location.status == LocationServiceStatus.Failed)
        {
            StartCoroutine("FindLocation");
        }
    }

    IEnumerator FindLocation()
    {
            // Starts the location service.
            Input.location.Start();

            // Waits until the location service initializes
            int maxWait = 10;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                displayText.text = ("Processing...");
                maxWait--;
            }

            // If the service didn't initialize in 20 seconds this cancels location service use.
            if (maxWait < 1)
            {
                displayText.text = ("Timed out");
                debugController.ShowDebugWarning("Location service timed out");
                yield break;
            }

            // If the connection failed this cancels location service use.
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                displayText.text = ("Unable to determine device location");
                debugController.ShowDebugError("Location service failed");
                yield break;
            }
            else
            {
                // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
                displayText.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude /*+ " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " "*/ + Input.location.lastData.timestamp);
            }

            // Stops the location service if there is no need to query location updates continuously.
            //Input.location.Stop();

    }

    public void StopLocation()
    {
        Input.location.Stop();
    }

   private void Update()
    {
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            displayText.text = ("Unable to determine device location");
            return;
        }
        else
        {
            corX = Input.location.lastData.latitude;//63.755141f;
            corZ = Input.location.lastData.longitude;//11.313448f;
        
            locX = (corX - orgX) * 111139;
            locZ = (orgZ - corZ) * 111139; //In Unity, left is positive. On the map, right is positive.
            userObject.transform.position = new Vector3(locX, 0f, locZ);
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            //displayText.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

        }
    }
}
