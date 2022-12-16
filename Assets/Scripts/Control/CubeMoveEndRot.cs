using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveEndRot : MonoBehaviour
{
    private Camera mainCamera;

    private bool isMove;
    public float speed;

    private Vector3 destination;
    public Transform chracter;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        destination.y = transform.position.y;
        isMove = true;
    }

    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }

            var dir = destination - transform.position;
            chracter.transform.forward = -dir;
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }
}
