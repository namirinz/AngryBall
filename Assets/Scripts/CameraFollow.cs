using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool follow = false;
    private Vector3 velocity = Vector3.zero;
    
    void FixedUpdate()
    {
        if (follow)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}