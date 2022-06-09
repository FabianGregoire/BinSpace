using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAsteroid : MonoBehaviour
{
    public Transform grabPosition;
    public bool stopGrab;
    // Start is called before the first frame update
    void Start()
    {
        stopGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stopGrab);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (stopGrab)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                Debug.Log("Ungrab now");
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                collision.gameObject.transform.position = grabPosition.position;
                collision.gameObject.transform.SetParent(transform);
                Debug.Log("Grab now");
            }
        }
    }
}
