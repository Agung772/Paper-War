using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speedCam;
    public Vector3 offset;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speedCam * Time.deltaTime);

        if (!PlayerController.instance.playerOperation) offset.x = 0;
        else offset.x = 8;
    }
}
