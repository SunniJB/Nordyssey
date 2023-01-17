using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GetDeviceLocation : MonoBehaviour
{
    public Text displayText;

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
    private void Start()
    {
        StartCoroutine("FindLocation");
    }
    IEnumerator FindLocation()
    {
            // Starts the location service.
            Input.location.Start();

            // Waits until the location service initializes
            int maxWait = 20;
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
                yield break;
            }

            // If the connection failed this cancels location service use.
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                displayText.text = ("Unable to determine device location");
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
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            displayText.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
    }
}
