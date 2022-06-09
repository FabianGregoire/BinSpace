using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspirateur : MonoBehaviour
{
    public float vitesseAspiration;
    /*public GameObject[] allEnemies;*/

    // Start is called before the first frame update
    void Start()
    {
        /*allEnemies = GameObject.FindGameObjectsWithTag("Enemy");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var rigidBody = other.GetComponent<Rigidbody2D>();
        other.transform.position = Vector3.MoveTowards(other.transform.position, transform.parent.position, vitesseAspiration * Time.deltaTime / rigidBody.mass);
    }
}
