using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX : MonoBehaviour
{
    float rotSpeed = 1.5f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.down * rotSpeed * mouseX);
        }


    }
}
