using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 current_position = rb.transform.position;
        if (current_position.y > -5.1)
        {
            rb.velocity = new Vector3(0, -6, 0);
        }
    }
}
