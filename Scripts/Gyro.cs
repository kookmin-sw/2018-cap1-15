using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {
    private int gyroCoin = 0;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
    }
    private bool EnableGyro()
    {
        if (gyroCoin == 1)
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0, 0, 1, 0);

                return true;
            }
        }
        return false;
    }
    private void Update()
    {
        if (EnableGyro())
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
    public void GyroOn()
    {
        Input.gyro.enabled = true;
        gyroCoin = 1;
    }
    public void GyroOff()
    {
        Input.gyro.enabled = false;
        gyroCoin = 0;
    }
    
}
