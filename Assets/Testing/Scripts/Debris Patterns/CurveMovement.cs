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
    private bool hitObject;
    /*public CameraMovement GameCamera;*/

    void Start()
    {
        /*rb.position = initialPosition;*/
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!hitObject && mapEntered)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitObject = true;
        }
    }

    public void Move()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, (moveDirection.y + Mathf.Sin(Time.time * (2 * math.PI)) * 3) * moveSpeed);
        }
    }
}




