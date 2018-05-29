
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using System;

public class Tobro  : MonoBehaviour {

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
}
