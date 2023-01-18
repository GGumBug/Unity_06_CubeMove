using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackBase
{
    public float speed = 20f;

    private void Start()
    {
        Invoke("DestroySelf", 4f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
