using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{

    public bool activateOnCameraEnter;
    public float moveSpeed;
    public Vector2 initialPosition;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    public CameraMovement GameCamera;

    void Start()
    {
        rb.position = initialPosition;
        if (GameCamera == null)
        {
            GameCamera = Camera.main.GetComponent<CameraMovement>();
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {

        Move();
    }

    void Move()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
}

