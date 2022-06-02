using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 target;

    // Update is called once per frame
    void Update()
    {
        //Porcessing Inputs
    }

    void FixedUpdate()
    {
        target =  new Vector2(transform.position.x + 1, 0);
        Move();
        //Physics calculations
    }

    void Move()
    {
        float step = moveSpeed * Time.deltaTime;
        // TODO stop the camera when reaching the map endpoint (just with an if statement)
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

}
