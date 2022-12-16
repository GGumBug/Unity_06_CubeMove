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
        for (int i = 0; i < count + 1; i++)
        {
            float randX = Random.Range(-100f, 100f);
            float randZ = Random.Range(-100f, 100f); 
            
            var go = OpenOBJ("Heart");            
            go.transform.position = new Vector3(randX, 0f, randZ);
        }

    }
}
