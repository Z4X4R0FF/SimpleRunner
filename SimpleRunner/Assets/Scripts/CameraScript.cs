using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float forwardSpeed = 20f;
    void Update()
    {
        if (LevelManager.StartGame)
            transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);
    }
}
