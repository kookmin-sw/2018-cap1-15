
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class ToTri : MonoBehaviour {

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneToTri()
    {
        StartCoroutine(SceneToTriC());
    }

    public void SceneToTriS()
    {
        StopAllCoroutines();
    }
    IEnumerator SceneToTriC()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("a");
    }

    public void SceneToAr()
    {

        StartCoroutine(SceneToArC());
    }
    public void SceneToArS()
    {
        StopAllCoroutines();
    }
    IEnumerator SceneToArC()
    {

        yield return new WaitForSeconds(3);
        StartCoroutine("SwitchTo3dAr");
        SceneManager.LoadScene("ar2");
    }

    IEnumerator SwitchTo3dAr()
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "vuforia"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active, see
        if (String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
    }
}

