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
    public BoxCollider2D grabCollider;
    private bool enterKeyPressed = false;
    private bool grabKeyPressed = false;
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _victoryText;
    [SerializeField] private GameObject _looseText;

    void Start()
    {
        screenBounds = new Vector2(-100, -5); // Set the camera screen size by hand since I can't get to retrieve it's size with a component
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        aspirateur.SetActive(false);
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
            grabCollider.enabled = true;
            grabAsteroidClass.stopGrab = false;
        }
        else if(!grabKeyPressed)
        {
            grabCollider.enabled = false;
            if (!grabAsteroidClass.stopGrab)
            {
                grabAsteroidClass.stopGrab = true;
            }
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
            /*Time.timeScale = 0f;*/
            _endMenu.SetActive(true);
            _victoryText.SetActive(false);
            _looseText.SetActive(true);
            Debug.Log("YOU LOST !");
        }else if(collision.gameObject.tag == "Finish")
        {
            isPlayerDead = true;
            _endMenu.SetActive(true);
            _victoryText.SetActive(true);
            _looseText.SetActive(false);
            Debug.Log("YOU WON !");
        }
    }
}