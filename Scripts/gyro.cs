using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyro : MonoBehaviour {
    int gyroCoin = 0;

    Quaternion origin = Quaternion.identity;


    void Start()
    {
    }


    void Update()
    {
        if (Input.gyro.enabled)
        {
            // reset origin on touch or not yet set origin
            if (Input.touchCount > 0 || origin == Quaternion.identity)
            {
                origin = Input.gyro.attitude;
            }
                transform.localRotation = origin * Quaternion.Inverse(Input.gyro.attitude);
            
        }
    }


    void OnGUI()
    {
        GUILayout.Label(origin.eulerAngles + " <- origin");
        GUILayout.Label(Input.gyro.attitude.eulerAngles + " <- gyro");
        GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles + " <- inv gyro");
        GUILayout.Label(transform.localRotation.eulerAngles + " <- localRotation");
    }


    public void gyroOn()
    {
        Input.gyro.enabled = true;
        origin = new Quaternion(0, 0, 0, 0);
        gyroCoin = 1;
    }
    public void gyroOff()
    {
        Input.gyro.enabled = false;
        gyroCoin = 0;
    }
    
}
