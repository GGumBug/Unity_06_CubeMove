using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponManager : MonoBehaviour
{
    public XRRayInteractor Interactor;

    GameObject setWeapon;

    public void SetWeapon(string weaponName)
    {

        if (setWeapon != null)
            return;

        var res = Resources.Load<GameObject>("Weapon/"+weaponName);
        if (res == null)
        {
            Debug.Log($"weaponName : {weaponName}�� �����ϴ�.");
            return;
        }

        setWeapon = Instantiate(res);
        setWeapon.SetActive(false);
        setWeapon.GetComponent<BoxCollider>().enabled = false; // ��ġ�ϱ����� �������� ���ذ� �ɱ�� false��
        setWeapon.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interactor == null)
            return;

        if (setWeapon == null)
            return;

        RaycastHit hit;
        if (Interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            setWeapon.transform.position = hit.point;
            setWeapon.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                setWeapon.GetComponent<BoxCollider>().enabled = true;
                setWeapon.GetComponent<Rigidbody>().useGravity = true;
                setWeapon = null;
            }
        }
        else
        {
            Debug.Log("�����Ҽ� ���� �����Դϴ�.");
            Destroy(setWeapon.gameObject);
            setWeapon = null;
        }
    }
}
