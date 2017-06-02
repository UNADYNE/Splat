using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;


    void Start()
    {

    }

    void LateUpdate()
    {
        Follow(); 
    }

    void Follow()
    {
        transform.position = target.position + offset;
        //transform.LookAt(target);
    }
}
