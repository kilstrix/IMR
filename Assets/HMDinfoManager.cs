using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDinfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!XRSettings.isDeviceActive )
        {
            Debug.Log("no headset");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMDDisplay")) 
        {
            Debug.Log("Using MockHMD");
        }
        else
        {
            Debug.Log("headset" + XRSettings.loadedDeviceName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
