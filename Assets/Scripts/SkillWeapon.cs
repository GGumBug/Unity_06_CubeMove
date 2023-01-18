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

    // 이 무기를 잡았을때 활성화
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
        // 무기가 선택되지 않았을경우 X
        if (isSelected == false)
            return;
        // 인터렉터가 없다면 실행 X
        if (Interactor == null)
            return;
        // 렉티클이 없다면 실행 X
        if (recticle == null)
            return;

        // 인터렉터의 레이케스트를 받아와서 충돌했는지 체크
        RaycastHit hit;
        if (Interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            // 충돌했다면 해당 위치에 텍티클을 이동
            recticle.transform.position = hit.point;

            // 렉티클을 활성화
            recticle.SetActive(true);
        }
        else
        {
            // 충돌하지 않았다면 비활성화
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
