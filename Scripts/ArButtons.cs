
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class ArButtons : MonoBehaviour {
    public GameObject Tri;
    public GameObject Cam;
    public GameObject MoveObject;
    private int motionCoin = 0;
    Vector3 originTr;
    Vector3 originTa;
    // Use this for initialization
    Animation Animationobj;
    void Start() {
        Animationobj = Tri.GetComponentInChildren<Animation>();
        originTr = Tri.transform.position;
        originTa = MoveObject.transform.position;
         }

    // Update is called once per frame
    void Update() {
        // Tri.transform.rotation = new Quaternion(Cam.transform.rotation.x, Cam.transform.rotation.y, Cam.transform.rotation.z,0);
        

    }

    IEnumerator GoToMenuC()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("startScene/tmpUI_03");
    }

    public void OtherMotion()
    {

        motionCoin = UnityEngine.Random.Range(0, 7);
        switch (motionCoin) {
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
        int moveX = UnityEngine.Random.Range(0, 100);
        int moveY = UnityEngine.Random.Range(0, 100);
        int moveZ = UnityEngine.Random.Range(0, 100);
     
        iTween.MoveTo(Tri, iTween.Hash("x",moveX,"z",moveZ,"time",4, "orienttopath", true));
    }
    public void ReseetPostion()
    {
        SceneManager.LoadScene("ar");
    }
}
