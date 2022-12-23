using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    #region SingleTone
    public static MonsterManager Instance;

    public static MonsterManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@MonsterManager");
            Instance = go.AddComponent<MonsterManager>();

            DontDestroyOnLoad(go);
        }

        return Instance;
    }
    #endregion

    public List<GameObject> monsterList = new List<GameObject>();

    public GameObject OpenMonster(string prefabName)
    {
        Object obj = Resources.Load($"Monster/{prefabName}");
        GameObject go = (GameObject)Instantiate(obj);
        monsterList.Add(go);

        return go;
    }

    public void CreateMonster(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var go = OpenMonster("Monster");
            var monster = go.GetComponent<Monster>();
            monster.SetTarget(GameManager.GetInstance().player.transform);
            go.transform.position = GetMonsterPosition();
        }

    }

    public Vector3 GetMonsterPosition()
    {
        Vector3 curPos = Vector3.zero;

        int rand = Random.Range(0,2);

        float width = 180f;
        float height = 180f;

        if (rand == 0)
        {
            float posX = Random.Range(0, 2);
            posX = posX == 0 ? width / 2 : -width / 2; // 0 일때 95 1일때 -95

            float posZ = Random.Range(-height/2,height/2); 

            curPos = new Vector3(posX, 0 ,posZ);
        }
        else
        {
            float posZ = Random.Range(0, 2);
            posZ = posZ == 0 ? width / 2 : -width / 2;

            float posX = Random.Range(-height / 2, height / 2);

            curPos = new Vector3(posX, 0, posZ);
        }


        return curPos;
    }
}
