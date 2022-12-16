using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region SingleTone
    public static UIManager Instance;

    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@UIManager");
            Instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }

        return Instance;
    }
    #endregion

    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string prefabName)
    {
        if (uiList.ContainsKey(prefabName) == false)
        {
            Object obj = Resources.Load($"UI/{prefabName}");
            GameObject go = (GameObject)Instantiate(obj);
            uiList.Add(prefabName, go);
        }
        else
            uiList[prefabName].SetActive(true);

    }

    public void CloseUI(string prefabName)
    {
        if (uiList.ContainsKey(prefabName) == true)
        {
            uiList[prefabName].SetActive(false);
        }
    }

    public GameObject GetUI(string prefabName)
    {
        if (uiList.ContainsKey(prefabName))
        {
            return uiList[prefabName];
        }

        return null;
    }
}
