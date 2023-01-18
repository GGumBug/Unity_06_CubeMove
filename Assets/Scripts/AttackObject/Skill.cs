using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : AttackBase
{
    float duration = 1f;

    private void OnEnable() // GameObject 가 True가 될때마다 발동
    {
        Invoke("DestroySelf", duration);
    }
    
    void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
