using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private float speedFactor = 0.5f;

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
        }
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 lookPos = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 2f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AttackBase>())
        {
            transform.position = MonsterManager.GetInstance().GetMonsterPosition();
        }

    }
}
