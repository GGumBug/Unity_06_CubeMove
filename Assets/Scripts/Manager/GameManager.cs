using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SingleTone
    public static GameManager Instance;

    private void Start()
    {
        ObjectManager.GetInstance().CreateHeart(1);
        MonsterManager.GetInstance().CreateMonster(30);
    }

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            Instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return Instance;
    }
    #endregion

    public Player player = new Player();

    private void Update()
    {
        //MinusHp();
    }

    void MinusHp()
    {
        player.hp -= 0.2f;
        UIPlayer uiPlayer = UIManager.GetInstance().GetUI("UIPlayer").GetComponent<UIPlayer>();
        uiPlayer.RefreshUI();
        if (player.hp <= 0)
        {
            Death();
            player.hp = 0;
        }
    }

    public void Death()
    {
        UIManager.GetInstance().OpenUI("UIDeath");
        player.transform.position = Vector3.zero + Vector3.up;
    }
}
