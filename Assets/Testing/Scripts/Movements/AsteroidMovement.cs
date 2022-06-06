using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    public int rotationSpeed;
    public int rotationDirection;
    public Vector2 moveDirection;
    public float moveSpeed;
    public Rigidbody2D rb;
    public bool mapEntered = false;


    private void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void FixedUpdate()
    {
        if (mapEntered)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            Move();
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * rotationDirection);
    }
}
