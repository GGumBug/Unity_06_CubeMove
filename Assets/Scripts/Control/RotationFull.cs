using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFull : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float speed = 2f;

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.down * speed * mouseX);
            transform.Rotate(Vector3.right * speed * mouseY);
        }
    }
}
