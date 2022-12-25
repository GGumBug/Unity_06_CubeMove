using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 100;
    public float hp = 100f;
    public int heartCount_;

    UIPlayer uiPlayer;

    private void Awake()
    {
        GameManager.GetInstance().player = this;
    }

    private void Update()
    {
        int heartCount = ObjectManager.GetInstance().objList.Count;
        for (int i = 0; i < heartCount; i++) 
        {
            var heart = ObjectManager.GetInstance().objList[i];
            //Debug.Log($"i : {i}    dist : {Vector3.Distance(transform.position, heart.transform.position)}");
            if (Vector3.Distance(transform.position, heart.transform.position) < 5f)
            {
                hp = maxHp;
                heartCount_++;
                uiPlayer = GetUIPlayer();
                uiPlayer.RefreshUI();
                uiPlayer.heartCount.text = $"Heart : {heartCount_}";

                heart.transform.position = ObjectManager.GetInstance().GetGeneratePosition();
            }
        }

        int monsterCount = MonsterManager.GetInstance().monsterList.Count;
        for (int i = 0; i < monsterCount; i++)
        {
            var monster = MonsterManager.GetInstance().monsterList[i];
            //Debug.Log($"i : {i}    dist : {Vector3.Distance(transform.position, heart.transform.position)}");
            if (Vector3.Distance(transform.position, monster.transform.position) < 5f)
            {
                uiPlayer = GetUIPlayer();
                hp -= 30;
                uiPlayer.RefreshUI();

                monster.transform.position = MonsterManager.GetInstance().GetMonsterPosition();

                if (hp <= 0)
                {
                    hp = 0;
                    GameManager.GetInstance().Death();
                }
            }
        }
    }

    UIPlayer GetUIPlayer()
    {
        uiPlayer = UIManager.GetInstance().GetUI("UIPlayer").GetComponent<UIPlayer>();

        return uiPlayer;
    }



}
