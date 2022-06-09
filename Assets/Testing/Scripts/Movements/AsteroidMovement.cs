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
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Move()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * rotationDirection);
    }
}
