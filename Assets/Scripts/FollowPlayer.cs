using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform target;
    public float zOffset;

    public float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;

    void Update() {
        // var targetPos = target.position;
        // transform.position = new Vector3(targetPos.x, targetPos.y, zOffset);
        
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, zOffset));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
