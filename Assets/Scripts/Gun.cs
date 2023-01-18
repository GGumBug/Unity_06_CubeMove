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

        var bulletGo = Instantiate(bullet, gunRoot.position, gunRoot.rotation); //컴포넌트에 들어있고 그 변수를 인스턴시에이트 해주면 컴포넌트에 들어있는 게임오브젝트가 복사된다.
        // 지금 false 상태로 복사를 하기 때문에 생성하고 true를 해줘야된다.
        bulletGo.gameObject.SetActive(true);

        Invoke("CheckDelay", delay);

    }

    void CheckDelay()
    {
        canShoot = true;
    }

}
