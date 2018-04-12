using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriAni : MonoBehaviour {
    public GameObject tric;
    public AudioSource sounds;
    public AudioSource tria;
    public GameObject efe;
    int ontoken = 0;
    int randomeMotion = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine("DoAni");
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }

    IEnumerator DoAni()
    {
        efe.SetActive(false);
        ontoken = 1;
        tria.Play();
        Animation animationobj = tric.GetComponentInChildren<Animation>();
        animationobj.Play("Walk");
        iTween.MoveTo(tric, iTween.Hash("path", iTweenPath.GetPath("tr"), "easeType", "easeOutCirc", "time", 5, "orienttopath", true));
        yield return new WaitForSeconds(2.5f);
        animationobj.Play("Run");
        yield return new WaitForSeconds(2.5f);
        animationobj.Play("Attack");
        sounds.Play();
        yield return new WaitForSeconds(1.5f);
  
        animationobj.Play("Run Die");
        yield return new WaitForSeconds(1.5f);

        animationobj.Play("Hurt");
        yield return new WaitForSeconds(1.5f);

        animationobj.Play("Stand Die");
        yield return new WaitForSeconds(1.5f);

        animationobj.Play("Idle");
        ontoken = 0;

        while (true)
        {
            randomeMotion = Random.Range(0, 5);
            switch (randomeMotion)
            {
                case 0:
                    animationobj.Play("Walk");
                    yield return new WaitForSeconds(2.5f);
                    break;

                case 1:
                    animationobj.Play("Run");
                    yield return new WaitForSeconds(2.5f);
                    break;
                case 2:
                    animationobj.Play("Attack");
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 3:
                    animationobj.Play("Run Die");
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 4:
                    animationobj.Play("Hurt");
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 5:
                    animationobj.Play("Stand Die");
                    yield return new WaitForSeconds(1.5f);
                    break;
            }
                    animationobj.Play("Idle");
                    yield return new WaitForSeconds(1.5f);

        }
    }
}
