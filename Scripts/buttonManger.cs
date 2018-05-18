
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class buttonManger : GvrAllEventsTrigger
{

    public GameObject Uis;
    public GameObject TriO;
    public GameObject TriB;
    public GameObject BroO;
    public GameObject BroB;
    public GameObject cam;
    int ist;
    string tname;
    string outname;
    int TriOpend = 0;
    int BroOpend = 0;
    int vrCoin = 0;
    // Use this for initialization
    void Start()
    {
        //HideCube2();
        OnPointerEnter.AddListener(Getingtarget);
        OnPointerUp.AddListener(Getingtargetu);
        OnPointerExit.AddListener(Getingtargeto);
        UnityEngine.XR.XRSettings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Getingtarget(GameObject target, PointerEventData eventData)
    {
        if (target)
            tname = target.name;
    }
    public void Getingtargetu(GameObject target, PointerEventData eventData)
    {
        if (target)
            tname = target.name;
    }

    public void Getingtargeto(GameObject target, PointerEventData eventData)
    {
        if (target)
            outname = target.name;
    }
    // later we should change the function name like Dino1,Dino2 for reusability
    public void Triopen()
    {
        if (TriOpend == 0)
        {
            TriO.SetActive(true);
            TriB.SetActive(true);
            TriOpend = 1;
        }
    }
    public void Broopen()
    {
        if (BroOpend == 0)
        {
            BroO.SetActive(true);
            BroB.SetActive(true);
            BroOpend = 1;
        }
    }
    public void ShowCube2()
    {
        print(tname);
        // Do nothing now. just for test function
        // after should delete it :D
    }

    public void HideCube2()
    {
        Uis.SetActive(false);
    }
    IEnumerator DoWait()
    {
        outname = "0";
        yield return new WaitForSeconds(3);
        if (outname == "0")
            SceneManager.LoadScene("k");
        print(outname);
        // Have to make delay system ;(

    }
    public void Change3d22d()
    {
        //StartCoroutine(SwitchTo2D());
        if (vrCoin == 0)
        {
            StartCoroutine(SwitchTo2D());
            //cam.GetComponent<Gyro>().GyroOn();
            vrCoin = 1;
        }
        else
        {
            StartCoroutine(SwitchToVR());
            vrCoin = 0;
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
    public void Change2d23D()
    {
        StartCoroutine(SwitchToVR());
 
    }
    IEnumerator SwitchTo2D()
    {
        // Empty string loads the "None" device.
        XRSettings.LoadDeviceByName("");

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;

        // Not needed, since loading the None (`""`) device takes care of this.
        // XRSettings.enabled = false;

        // Restore 2D camera settings.
        ResetCameras();
    }

    // Resets camera transform and settings on all enabled eye cameras.
    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {

                // Reset local position.
                // Only required if you change the camera's local position while in 2D mode.
                cam.transform.localPosition = Vector3.zero;

                // Reset local rotation.
                // Only required if you change the camera's local rotation while in 2D mode.
                cam.transform.localRotation = Quaternion.identity;

                // No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
                // cam.ResetAspect();

                // No need to reset `fieldOfView`, since it's reset automatically.
            }
        }
    }
    // Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
    // `yield SwitchToVR()` if calling from inside another coroutine.
    IEnumerator SwitchToVR()
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
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