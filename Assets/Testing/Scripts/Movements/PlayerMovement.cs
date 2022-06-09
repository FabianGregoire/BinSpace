using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GrabAsteroid grabAsteroidClass;
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
    public GameObject aspirateur;
    public GameObject grab;
    private bool enterKeyPressed = false;
    private bool grabKeyPressed = false;

    void Start()
    {
        screenBounds = new Vector2(-100, -5); // Set the camera screen size by hand since I can't get to retrieve it's size with a component
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        aspirateur.SetActive(false);
        grab.SetActive(false);
        grabAsteroidClass = FindObjectOfType<GrabAsteroid>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        //Porcessing Inputs
        if (!isPlayerDead && enterKeyPressed)
        {
            aspirateur.SetActive(true);
        }
        else
        {
            aspirateur.SetActive(false);
        }
        if (!isPlayerDead && grabKeyPressed)
        {
            grab.SetActive(true);
            grabAsteroidClass.stopGrab = false;
        }
        else
        {
            grab.SetActive(false);
            grabAsteroidClass.stopGrab = true;
        }
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
        enterKeyPressed = Input.GetKey(KeyCode.Space);
        grabKeyPressed = Input.GetKey(KeyCode.D);
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
        if (collision.gameObject.tag == "Enemy" && !isPlayerDead)
        {
            explosion.Play();
            myAnimationController.SetBool("PlayExplosion", true);
            isPlayerDead = true;
            Debug.Log("YOU LOST !");
        }else if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("YOU WON !");
        }
    }
}