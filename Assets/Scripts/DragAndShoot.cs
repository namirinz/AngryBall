using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Rigidbody rb;
    private bool isShoot = false;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    public float forceMultiplier = 1f;

    [SerializeField] private CameraFollow cameraFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        DrawTrajectory.Instance.HideLine();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 force = new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier;

        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(force, rb, transform.position);
        }
    }

    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        rb.useGravity = true;
        cameraFollow.follow = true;
        Shoot(mousePressDownPos - mouseReleasePos);
    }

    void Shoot(Vector3 force)
    {
        if (!isShoot)
        {
            rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
            isShoot = true;
        }
    }
}
