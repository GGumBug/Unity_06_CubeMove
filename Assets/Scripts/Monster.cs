using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private float speedFactor = 2f;

    public Transform target;

    private void Start()
    {
        float randSpeedFactor = Random.Range(1 - speedFactor, 1 + speedFactor);
        speed *= randSpeedFactor;
    }

    public void SetTarget(Transform tr)
    {
        target = tr;
    }

    private void Update()
    {
        if (target == null)
        {
            return;

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 lookPos = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 2f * Time.deltaTime);
        }
    }


}
