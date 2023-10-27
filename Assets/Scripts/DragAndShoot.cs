using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Rigidbody rb;
    
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 playerStartPosition = new Vector3(0, -0.76f, 0.4f);
    private Vector3 cameraStartPosition = Vector3.zero;
    
    public float forceMultiplier = 1f;
    private float timePassed = 0f;
    private bool isShoot = false;

    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WindManager windManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localPosition = playerStartPosition;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        rb.rotation = Quaternion.identity;
        
        isShoot = false;
        timePassed = 0f;

        cameraFollow.transform.position = cameraStartPosition;
        cameraFollow.follow = false;
        DrawTrajectory.Instance.HideLine();
    }

    private void OnMouseDown()
    {
        if (gameManager.gameHasEnded) return;
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (gameManager.gameHasEnded) return;
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 force = new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier;

        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(force, rb, transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (gameManager.gameHasEnded) return;
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        rb.useGravity = true;
        cameraFollow.follow = true;
        Shoot(mousePressDownPos - mouseReleasePos);
    }

    void Shoot(Vector3 force)
    {
        if (!isShoot)
        { ;
            // Force remove from wind
            force = new Vector3(force.x, force.y, force.y) * forceMultiplier;
            force -= windManager.windDirection * windManager.windForce;
            rb.AddForce(force);
            isShoot = true;
        }
    }

    void Update()
    {
        if (isShoot)
        {
            timePassed += Time.deltaTime;
        }

        if (isShoot && timePassed > 3)
        { 
            Start();
            windManager.UpdateWind();
            gameManager.playerRemaining--;
        }
    }
    
}
