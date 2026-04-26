using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{
    




    public Transform target;

    public float smoothTime = 0.2f;

    float LookAheadDistance = 2f;

    public float smoothSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()

    {

        Vector3 pos = transform.position;

        Vector3 diff = target.position - transform.position;

      

        float direction = Input.GetAxis("Horizontal");


        Vector3 targetPos = target.position + new Vector3(LookAheadDistance * direction, 0, -10);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }


 
}

