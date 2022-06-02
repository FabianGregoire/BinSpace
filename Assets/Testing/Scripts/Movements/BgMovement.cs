using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour
{
    public int rotationSpeed;
    public CameraMovement GameCamera;

    private void Start()
    {
        if(GameCamera == null)
        {
            GameCamera = Camera.main.GetComponent<CameraMovement>();
        }
    }

    void FixedUpdate()
    {
        Move();
        //Physics calculations
    }
    void Move()
    {
        //transform.position = new Vector2(GameCamera.transform.position.x, transform.position.y);

        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
