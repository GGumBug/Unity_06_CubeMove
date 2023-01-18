using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SkillWeapon : MonoBehaviour
{
    public string recticlePrefName;
    public GameObject recticle;

    public string skillPrefName;
    GameObject skill;

    // �� ���⸦ ������� Ȱ��ȭ
    public bool isSelected;
    public XRRayInteractor Interactor;

    float duration = 1f;
    float delay = 1f;
    bool canUse = true;

    private void Start()
    {
        var res = Resources.Load<GameObject>(recticlePrefName);
        recticle = Instantiate(res);
        recticle.SetActive(false);

        var skillgo = Resources.Load<GameObject>(skillPrefName);
        skill = Instantiate(skillgo);
        skill.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ⱑ ���õ��� �ʾ������ X
        if (isSelected == false)
            return;
        // ���ͷ��Ͱ� ���ٸ� ���� X
        if (Interactor == null)
            return;
        // ��ƼŬ�� ���ٸ� ���� X
        if (recticle == null)
            return;

        // ���ͷ����� �����ɽ�Ʈ�� �޾ƿͼ� �浹�ߴ��� üũ
        RaycastHit hit;
        if (Interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            // �浹�ߴٸ� �ش� ��ġ�� ��ƼŬ�� �̵�
            recticle.transform.position = hit.point;

            // ��ƼŬ�� Ȱ��ȭ
            recticle.SetActive(true);
        }
        else
        {
            // �浹���� �ʾҴٸ� ��Ȱ��ȭ
            recticle.SetActive(false);
        }
        
        
    }

    public void OnSelect()
    {
        isSelected = true;
    }

    public void OnDeSelect()
    {
        isSelected = false;

        recticle.SetActive(false);
    }

    public void OnActive()
    {
        if (canUse == false)
            return;

        canUse = false;

        skill.transform.position = recticle.transform.position;
        skill.SetActive(true);

        Invoke("CheckDelay", delay);
    }

    public void CheckDelay()
    {
        canUse = true;
    }
}
