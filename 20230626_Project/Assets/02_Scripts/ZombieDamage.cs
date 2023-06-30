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
        hpBar.color = Color.green; // hp�ٿ� ü�� ����

        CapCol = GetComponent<CapsuleCollider>();
        an = GetComponent<Animator>();
        BloodEffect = Resources.Load<GameObject>("Effect/Blood");
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("BULLET"))
        {
            Destroy(col.gameObject); // col�� ������ ���� ���������
            GameObject blood = Instantiate(BloodEffect, col.transform.position, Quaternion.identity);
            Destroy(blood, 1.5f); // 1.5�� �� �� ȿ�� ����
            an.SetTrigger("IsHit");
            ZBHPManager();
        }
    }

    private void ZBHPManager()
    {
        hp = hp - 35f;
        hp = Mathf.Clamp(hp, 0f, 100f);//Mathf(�����Լ��� ��Ƴ��� ��) Clamp(�����ϴ�. ������. 0����, 100����)
        hpTxT.text = "HP : " + hp.ToString();
        hpBar.fillAmount = hp / hplmit; // ü�� �������� ��� �����ϴ� ����. ex) �Ѿ� �� �� ������ 65/100�� hpbar�� ����
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
        //ĸ���ݶ��̴��� ��Ȱ��ȭ
        IsDie = true;
        UIcanvas.enabled = false;

        Destroy(gameObject, 5.0f);
    }

}
