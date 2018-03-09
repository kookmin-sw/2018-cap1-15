
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttonManger : GvrAllEventsTrigger
{

    public GameObject Uis;
    int ist;
    string tname;
    string outname;
    // Use this for initialization
    void Start()
    {
        HideCube2();
    }

    // Update is called once per frame
    void Update()
    {
        OnPointerEnter.AddListener(Getingtarget);
        OnPointerUp.AddListener(Getingtargetu);
        OnPointerExit.AddListener(Getingtargeto);
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

    public void ShowCube2()
    {
        print(tname);
        if (tname == "Cube")
        {
            print("hell");
            if (Uis.activeInHierarchy == true)
            {
                Uis.SetActive(false);
            }
            else
            {
                Uis.SetActive(true);
            }
        }
        if (tname == "Cubes")
        {

            StartCoroutine(DoWait());

        }
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
        

    }

}