
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttonManger : GvrAllEventsTrigger
{

    public GameObject Uis;
    public GameObject TriO;
    public GameObject TriB;
    public GameObject BroO;
    public GameObject BroB;
    int ist;
    string tname;
    string outname;
    int TriOpend = 0;
    int BroOpend = 0;
    // Use this for initialization
    void Start()
    {
        //HideCube2();
        OnPointerEnter.AddListener(Getingtarget);
        OnPointerUp.AddListener(Getingtargetu);
        OnPointerExit.AddListener(Getingtargeto);
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
        if (tname == "TriCube")
        {
            if (TriOpend == 0)
            {
                TriO.SetActive(true);
                TriB.SetActive(true);
                TriOpend = 1;
            }
           // StartCoroutine(DoWait());

        }
        if (tname == "BroCube")
        {

            if (BroOpend == 0)
            {
                BroO.SetActive(true);
                BroB.SetActive(true);
                BroOpend = 1;
            }
            // StartCoroutine(DoWait());

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