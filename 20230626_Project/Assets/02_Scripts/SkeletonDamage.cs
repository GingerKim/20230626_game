using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SkeletonDamage : MonoBehaviour
{
    private Animator Anima;
    [SerializeField]
    private CapsuleCollider CapCol;
    private Rigidbody rd;
    public float hp = 60f;
    public float hplmit = 60f;
    public static bool IsDie = false;

    [SerializeField] private Canvas SkelCanvas;
    [SerializeField] private Image SkelhpBar;
    [SerializeField] private Text SkelhpTxT;


    void Start()
    {
        SkelCanvas = transform.GetChild(3).GetComponent<Canvas>();
        SkelhpBar = transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
        SkelhpBar.color = Color.blue;
        SkelhpTxT = transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>();

        CapCol = GetComponent<CapsuleCollider>();
        Anima = GetComponent<Animator>();
        rd = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("BULLET"))
        {
            Destroy(col.gameObject); // ���� �ƴ� �Ѿ��� ���ַ��� col�� �ٿ�����
            Anima.SetTrigger("IsHit");
            SKHPManager();

        }
    }

    private void SKHPManager()
    {
        hp = hp - 35f;
        if (hp <= 0)
            Die();
        hp = Mathf.Clamp(hp, 0f, 100f); // hp�� ������ 0�������� 100���� ����.
        SkelhpBar.fillAmount = hp / hplmit;
        SkelhpTxT.text = "HP : " + hp.ToString();

        if (SkelhpBar.fillAmount <= 0.3f)
            SkelhpBar.color = Color.red;
        else if (SkelhpBar.fillAmount <= 0.6f)
            SkelhpBar.color = Color.yellow;
    }

    void Die()
    {
        Anima.SetTrigger("IsDie");
        rd.isKinematic = true;
        CapCol.enabled = false;
        IsDie = true;
        // �׾����� ���� ������ ���� �����.

        SkelCanvas.enabled = false;
        Destroy(gameObject, 5.0f);
    }
}
