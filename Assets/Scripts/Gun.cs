using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunRoot;
    public Transform bullet;
    public ParticleSystem particle;

    public float delay = 0.5f;
    public float damage = 2;

    private bool canShoot = true;

    public void Shot()
    {
        if (canShoot == false)
        {
            return;
        }

        Debug.Log("Shot!");
        canShoot = false;

        particle.transform.position = gunRoot.position;
        particle.Play();

        var bulletGo = Instantiate(bullet, gunRoot.position, gunRoot.rotation); //������Ʈ�� ����ְ� �� ������ �ν��Ͻÿ���Ʈ ���ָ� ������Ʈ�� ����ִ� ���ӿ�����Ʈ�� ����ȴ�.
        // ���� false ���·� ���縦 �ϱ� ������ �����ϰ� true�� ����ߵȴ�.
        bulletGo.gameObject.SetActive(true);

        Invoke("CheckDelay", delay);

    }

    void CheckDelay()
    {
        canShoot = true;
    }

}
