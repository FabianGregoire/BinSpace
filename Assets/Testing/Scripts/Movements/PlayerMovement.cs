using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float xPlayerOffset = 9f;
    public Rigidbody2D rb;
    public CameraMovement GameCamera;
    public AudioSource explosion;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Vector2 moveDirection;
    private bool isPlayerDead = false;
    [SerializeField] private Animator myAnimationController;

    void Start()
    {
        screenBounds = new Vector2(-100, -5); // Set the camera screen size by hand since I can't get to retrieve it's size with a component
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        //Porcessing Inputs
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }

    void FixedUpdate()
    {
        if (!isPlayerDead)
        {
            Move();
        }
        //Physics calculations
    }

    void ProcessInputs()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(0, moveY);
    }

    void Move()
    {
        if(transform.position.y < 5 || transform.position.y > -5)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveDirection.y * moveSpeed);
        }
        transform.position = new Vector2(GameCamera.transform.position.x - xPlayerOffset, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            explosion.Play();
            myAnimationController.SetBool("PlayExplosion", true);
            isPlayerDead = true;
            Debug.Log("You lost");
        }
    }
}

//StraightMovement.Instance.Move();
//StraightMovement.instance.initialPosition = 2, 5;