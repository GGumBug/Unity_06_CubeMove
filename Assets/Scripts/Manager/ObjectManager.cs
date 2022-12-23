using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region SingleTone
    public static ObjectManager Instance;

    public static ObjectManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            Instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }

        return Instance;
    }
    #endregion

    public List<GameObject> objList = new List<GameObject>();

    public GameObject OpenOBJ(string prefabName)
    {
        Object obj = Resources.Load($"Object/{prefabName}");
        GameObject go = (GameObject)Instantiate(obj);
        objList.Add(go);

        return go;
    }

    public void CreateHeart(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var go = OpenOBJ("Heart");
            go.transform.position = GetGeneratePosition();
        }

    }

    public Vector3 GetGeneratePosition()
    {
        Vector3 curPos = Vector3.zero;

        while (true)
        {
            float width = 180f;
            float randX = Random.Range(-width/2, width/2);

            float height = 180f;
            float randZ = Random.Range(-height/2, height/2);

            curPos = new Vector3(randX, 0, randZ);
            if (Vector3.Distance(transform.position, curPos) > 2f)
                break;
        }


        return curPos;
    }
}
