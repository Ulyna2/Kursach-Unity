using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform trackingObject;
    void Update()
    {
        transform.position = new Vector3(trackingObject.position.x, transform.position.y, transform.position.z);
    }
}
