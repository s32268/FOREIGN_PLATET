using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;

    public float yOffset = -2f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = new Vector3(
            target.position.x,
            target.position.y + yOffset,
            transform.position.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}