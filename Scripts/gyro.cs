using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyro : MonoBehaviour {

    Vector3 gyroscope_rotation;
    
    void Update()
    {
        gyroscope_rotation.x += Input.gyro.rotationRateUnbiased.x;
        gyroscope_rotation.y += Input.gyro.rotationRateUnbiased.y;
    }

    public void gyroOn()
    {
        Input.gyro.enabled = true;
    }
    
}
