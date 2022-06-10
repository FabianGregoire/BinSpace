using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAsteroid : MonoBehaviour
{
    public Transform grabPosition;
    public bool stopGrab;
    private bool objectIsGrabbed = false;
    private GameObject grabbedObject;
    // Start is called before the first frame update
    void Start()
    {
        stopGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbedObject != null && stopGrab)
        {
            releaseObject(grabbedObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!stopGrab && !objectIsGrabbed)        
        {
            if (collision.gameObject.tag == "Enemy")
            {
                grabbedObject = collision.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbedObject.transform.position = grabPosition.position;
                grabbedObject.transform.SetParent(transform);
                objectIsGrabbed = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            grabbedObject = collision.gameObject;
            grabbedObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    public void releaseObject(GameObject objet)
    {
        if (objectIsGrabbed)
        {
            objet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            objet.transform.parent = transform.root;
            objet.transform.position = new Vector2(grabPosition.position.x, grabPosition.position.y);
            objet.GetComponent<Rigidbody2D>().velocity = new Vector2(objet.GetComponent<Rigidbody2D>().velocity.x * -2, objet.GetComponent<Rigidbody2D>().velocity.y * -2);
            objectIsGrabbed = false;
        }
    }

}
