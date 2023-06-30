using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDamage : MonoBehaviour
{
    private Animator an;
    [SerializeField] private GameObject BloodEffect;
    private CapsuleCollider CapCol;

    public float hp = 100f;
    public float hplmit = 100f;
    public static bool IsDie = false;

    [SerializeField] private Canvas UIcanvas;
    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpTxT;

    void Start()
    {
        UIcanvas = transform.GetChild(18).GetComponent<Canvas>();
        hpBar = transform.GetChild(18).GetChild(0).GetChild(0).GetComponent<Image>();
        hpTxT = transform.GetChild(18).GetChild(0).GetChild(1).GetComponent<Text>();
        hpBar.color = Color.green; // hp바에 체력 색깔

        CapCol = GetComponent<CapsuleCollider>();
        an = GetComponent<Animator>();
        BloodEffect = Resources.Load<GameObject>("Effect/Blood");
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("BULLET"))
        {
            Destroy(col.gameObject); // col이 없으면 좀비가 사라져버림
            GameObject blood = Instantiate(BloodEffect, col.transform.position, Quaternion.identity);
            Destroy(blood, 1.5f); // 1.5초 뒤 피 효과 삭제
            an.SetTrigger("IsHit");
            ZBHPManager();
        }
    }

    private void ZBHPManager()
    {
        hp = hp - 35f;
        hp = Mathf.Clamp(hp, 0f, 100f);//Mathf(수학함수만 모아놓은 것) Clamp(제한하다. 무엇을. 0에서, 100까지)
        hpTxT.text = "HP : " + hp.ToString();
        hpBar.fillAmount = hp / hplmit; // 체력 게이지가 닳게 구현하는 것임. ex) 총알 한 방 맞으면 65/100을 hpbar로 구현
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;

        if (hp <= 0)
            Die();
    }

    void Die()
    {
        an.SetTrigger("IsDie");
        CapCol.enabled = false;
        //캡슐콜라이더를 비활성화
        IsDie = true;
        UIcanvas.enabled = false;

        Destroy(gameObject, 5.0f);
    }

}
