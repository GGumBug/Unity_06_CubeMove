using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    public Slider playerHp;

    public void RefreshUI()
    {
        playerHp.maxValue = GameManager.GetInstance().player.maxHp;
        playerHp.value = GameManager.GetInstance().player.hp;
    }

}
