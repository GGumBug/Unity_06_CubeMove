using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : AttackBase
{
    float duration = 1f;

    private void OnEnable() // GameObject �� True�� �ɶ����� �ߵ�
    {
        Invoke("DestroySelf", duration);
    }
    
    void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
