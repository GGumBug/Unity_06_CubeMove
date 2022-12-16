using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController characterController;
    public Vector3 movePoint;
    public Camera mainCamera;

    private void Start()
    {
        speed = 30f;
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                movePoint = raycastHit.point;
                Debug.Log("movePoint : " + movePoint.ToString());
                Debug.Log("¸ÂÀº °´Ã¼ : " + raycastHit.transform.name);
            }

        }

        if (Vector3.Distance(transform.position, movePoint) > 0.1f)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 thisUpdatePoint = (movePoint - transform.position).normalized * speed;

        characterController.SimpleMove(thisUpdatePoint);
    }

}
