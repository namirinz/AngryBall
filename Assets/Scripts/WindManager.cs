using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public Vector3 windDirection;
    public float windForce;

    void Start()
    {
        UpdateWind();
    }
    
    public void UpdateWind()
    {
        windDirection = RandomWindDirection();
        windForce = RandomWindForce();
        
        print(windDirection);
        print(windForce);
        transform.LookAt(windDirection);
    }

    private Vector3 RandomWindDirection()
    {
        float winddirection_x = Random.Range(-1f, 1f);
        float winddirection_y = Random.Range(-1f, 1f);
        float winddirection_z = Random.Range(-1f, 1f);
        
        Vector3 windDirection = new Vector3(winddirection_x, winddirection_y, winddirection_z);
        return windDirection;
    }
    
    private float RandomWindForce()
    {
        float windForce = Random.Range(0f, 50f);
        return windForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
