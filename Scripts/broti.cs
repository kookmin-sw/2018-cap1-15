using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broti : MonoBehaviour {
    public GameObject tric;
    public AudioSource sounds;
    public AudioSource tria;
    public GameObject efe;
    int ontoken = 0;
    int randomeMotion = 0;
    // Use this for initialization
    void Start()
    {
        efe.SetActive(false);
        StartCoroutine("DoAni");
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator DoAni()
    {

        ontoken = 1;
        tria.Play();
        Animation animationobj = tric.GetComponentInChildren<Animation>();

        iTween.MoveTo(tric, iTween.Hash("path", iTweenPath.GetPath("br"), "easeType", "easeOutCirc", "time", 8, "orienttopath", true));
        animationobj.Play("Walk");
        yield return new WaitForSeconds(2.5f);
        yield return new WaitForSeconds(2.5f);
        sounds.Play();
        yield return new WaitForSeconds(1.5f);

        animationobj.Play("Idle2");
        yield return new WaitForSeconds(3.5f);

        animationobj.Play("Idle1");
        yield return new WaitForSeconds(1.5f);

        animationobj.Play("Die");
        yield return new WaitForSeconds(2.0f);

        animationobj.Play("Idle2");
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
                    animationobj.Play("Die");
                    yield return new WaitForSeconds(2.5f);
                    break;
                case 2:
                    animationobj.Play("Idle1");
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 3:
                    animationobj.Play("Idle2");
                    yield return new WaitForSeconds(1.5f);
                    break;
            }
            animationobj.Play("Idle2");
            yield return new WaitForSeconds(1.5f);
        }
    }
}
