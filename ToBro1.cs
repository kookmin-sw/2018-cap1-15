
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class ToBro1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SceneToBro()
    {

        StartCoroutine(SceneToBroC());
    }
    public void SceneToBroS()
    {
        StopAllCoroutines();
    }
    IEnumerator SceneToBroC()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ab");
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
        SceneManager.LoadScene("ar");
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
