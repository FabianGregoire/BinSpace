using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{

    public bool mapEntered = false;
    public float moveSpeed;
    public Vector2 initialPosition;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    /*public CameraMovement GameCamera;*/

    void Start()
    {
        /*rb.position = initialPosition;*/
    }

    void Update()
    {
        
    }

    public void Move()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}

