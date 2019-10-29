using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float xPos, zPos;
    public float moveSpeed, camZoom;

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        xPos = Input.GetAxis("Horizontal");
        zPos = Input.GetAxis("Vertical");
        movement.z = -xPos;
        movement.x = zPos;
        //transform.Translate(Vector3.forward * delta * moveSpeed);
        transform.Translate(movement * Time.deltaTime * moveSpeed,Space.World);
        if(Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            transform.Translate(transform.forward * Time.deltaTime * camZoom,Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            transform.Translate(-transform.forward * Time.deltaTime * camZoom,Space.World);
        }
    }
}
