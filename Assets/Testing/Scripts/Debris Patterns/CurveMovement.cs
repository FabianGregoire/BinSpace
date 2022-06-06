using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CurveMovement : MonoBehaviour
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
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (mapEntered == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            Move();
        }
    }

    void Move()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, (moveDirection.y + Mathf.Sin(Time.time * (2 * math.PI)) * 3) * moveSpeed);
        }
    }
}




