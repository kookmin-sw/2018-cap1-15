
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class ArButtonsT : MonoBehaviour {
    public GameObject Tri;
    public GameObject Cam;
    public GameObject MoveObject;
    private int motionCoin = 0;
    Vector3 originTr;
    Vector3 originTa;
    // Use this for initialization
    Animation Animationobj;
    void Start()
    {
        Animationobj = Tri.GetComponentInChildren<Animation>();
        originTr = Tri.transform.position;
        originTa = MoveObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Tri.transform.rotation = new Quaternion(Cam.transform.rotation.x, Cam.transform.rotation.y, Cam.transform.rotation.z,0);


    }

    public void ChangeMode2VrTri()
    {
        StartCoroutine(ChangeMode2VrTriC());
    }
    public void ChangeMode2VrTriS()
    {
        StopAllCoroutines();
    }
    IEnumerator ChangeMode2VrTriC()
    {

        yield return new WaitForSeconds(3);

        StartCoroutine(SwitchTo3dVr());
        SceneManager.LoadScene("a");
    }

    IEnumerator SwitchTo3dVr()
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard".

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
    public void OtherMotion()
    {

        motionCoin = UnityEngine.Random.Range(0, 7);
        switch (motionCoin)
        {
            case 0:
                Animationobj.Play("Attack");
                break;
            case 1:
                Animationobj.Play("Hurt");
                break;
            case 2:
                Animationobj.Play("Idle");
                break;
            case 3:
                Animationobj.Play("Run");
                break;
            case 4:
                Animationobj.Play("Run Die");
                break;
            case 5:
                Animationobj.Play("Stand Die");
                break;
            case 6:
                Animationobj.Play("Stand Still");
                break;
            case 7:
                Animationobj.Play("Walk");
                break;
        }
    }

    public void LookAtMe()
    {

    }
    public void RandomeMove()
    {
        int moveX = UnityEngine.Random.Range(0, 10);
        int moveY = UnityEngine.Random.Range(0, 100);
        int moveZ = UnityEngine.Random.Range(0, 10);

        iTween.MoveTo(Tri, iTween.Hash("x", moveX, "z", moveZ, "time", 4, "orienttopath", true));
    }
    public void ReseetPostion()
    {
        StartCoroutine(ReseetPostionC());
    }
    public void ReseetPostionS()
    {
        StopAllCoroutines();
    }
    IEnumerator ReseetPostionC()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ar2");
    }
}
