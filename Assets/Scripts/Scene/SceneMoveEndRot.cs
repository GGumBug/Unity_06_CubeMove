using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveEndRot : MonoBehaviour
{
    private void Awake()
    {
        GameManager.GetInstance();
        UIManager.GetInstance().OpenUI("UIPlayer");
    }
}
