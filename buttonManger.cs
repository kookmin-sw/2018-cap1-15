
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
    public GameObject Menus;
    int ist;
    string tname;
    string outname;
    int TriOpend = 0;
    int BroOpend = 0;
    int vrCoin = 0;
    int menuCOin = 0;
    // Use this for initialization
    void Start()
    {
        //HideCube2();
        /*
        OnPointerEnter.AddListener(Getingtarget);
        OnPointerUp.AddListener(Getingtargetu);
        OnPointerExit.AddListener(Getingtargeto);*/
        UnityEngine.XR.XRSettings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //          Getting Target Object 타겟 오브젝트 받던것. 안드로이드 빌드시 문제땜에 현재는 사용 안함. 
    /*
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
    }*/


    //          Tri Open

    public void Triopen()
    {
        StartCoroutine(TriOpenC());
    }
    public void TriOpenS()
    {
        StopAllCoroutines();
    }
    IEnumerator TriOpenC()
    {
        yield return new WaitForSeconds(3);
        if (menuCOin == 0)
        {
            TriO.SetActive(true);
            TriB.SetActive(true);
            TriOpend = 1;
        }
    }

    //          Bro Open
    public void Broopen()
    {
        StartCoroutine(BroOpenC());
    }
    public void BroOpenS()
    {
        StopAllCoroutines();
    }
    IEnumerator BroOpenC()
    {
        yield return new WaitForSeconds(3);
        if (menuCOin == 0) { 
                BroO.SetActive(true);
                BroB.SetActive(true);
                BroOpend = 1;
            }
    }

    //          Not Using Now
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

    //         Show Menu 
    public void ShowMenu()
    {
        StartCoroutine(ShowMenuC());
    }
    public void ShowMenuS()
    {
        StopAllCoroutines();
    }
    IEnumerator ShowMenuC()
    {

        yield return new WaitForSeconds(3);
        if (menuCOin == 0)
        {
            Menus.SetActive(true);
            menuCOin = 1;
        }
    }

    //          Go To Menu 
    public void GoToMenu()
    {
        StartCoroutine(GoToMenuC());
    }
    public void GoToMenuS()
    {
        StopAllCoroutines();
    }
    IEnumerator GoToMenuC()
    {

        yield return new WaitForSeconds(3);
        StartCoroutine(SwitchTo2D());
        SceneManager.LoadScene("startScene/tmpUI_03");
    }

    //          Menu Cancle
    public void Cancle()
    {
        StartCoroutine(CancleC());
    }
    public void CancleS()
    {
        StopAllCoroutines();
    }
    IEnumerator CancleC()
    {

        yield return new WaitForSeconds(3);
        Menus.SetActive(false);
        menuCOin = 0;
    }

    //          Change 3d -> 2d 
    public void Change3d22d()
    {
        StartCoroutine(Change3d22dC());
    }
    public void Change3d22dS()
    {
        StopAllCoroutines();
    }
    IEnumerator Change3d22dC()
    {
        yield return new WaitForSeconds(3);
        if (menuCOin == 0)
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
    }

    //          Change 2d -> 3d // StopAllCourtine use the 3d->2d Same as
    public void Change2d23D()
    {
        StartCoroutine(Change2d23DC());
 
    }
    IEnumerator Change2d23DC()
    {

        yield return new WaitForSeconds(3);
        if (menuCOin == 0)
            StartCoroutine(SwitchToVR());
    }

    //          SwitchTo2d ( for going to menu)
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