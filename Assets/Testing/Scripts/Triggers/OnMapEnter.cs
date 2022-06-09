using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMapEnter : MonoBehaviour
{

    public StraightMovement[] linearDebri;
    public AsteroidMovement[] asteroids;
    public CurveMovement[] curvilineDebri;

    // Start is called before the first frame update
    void Start()
    {
        linearDebri = FindObjectsOfType<StraightMovement>();
        asteroids = FindObjectsOfType<AsteroidMovement>();
        curvilineDebri = FindObjectsOfType<CurveMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<StraightMovement>() != null)
            {
                foreach (StraightMovement m in linearDebri)
                {
                    if (m.gameObject == collision.gameObject)
                    {
                        m.mapEntered = true;
                        m.Move();
                    }
                }
            }else if(collision.gameObject.GetComponent<AsteroidMovement>() != null)
            {
                foreach (AsteroidMovement m in asteroids)
                {
                    if (m.gameObject == collision.gameObject)
                    {
                        m.mapEntered = true;
                        m.Move();
                    }
                }
            }else if (collision.gameObject.GetComponent<CurveMovement>() != null)
            {
                foreach (CurveMovement m in curvilineDebri)
                {
                    if (m.gameObject == collision.gameObject)
                    {
                        m.mapEntered = true;
                        m.Move();
                    }
                }
            }
        }
    }
}
