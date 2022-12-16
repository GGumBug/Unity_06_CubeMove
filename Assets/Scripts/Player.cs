using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 100;
    public float hp = 100f;

    private void Start()
    {
        GameManager.GetInstance().player = this;
    }

    private void Update()
    {
        int heartCount = ObjectManager.GetInstance().objList.Count;
        for (int i = 0; i < heartCount; i++) 
        {
            var heart = ObjectManager.GetInstance().objList[i];
            Debug.Log($"i : {i}    dist : {Vector3.Distance(transform.position, heart.transform.position)}");
            if (Vector3.Distance(transform.position, heart.transform.position) < 5f)
            {
                hp = maxHp;

                float randX = Random.Range(-100f, 100f);
                float randZ = Random.Range(-100f, 100f);
                heart.transform.position = new Vector3(randX, 0f, randZ);
            }
        }       
    }

}
