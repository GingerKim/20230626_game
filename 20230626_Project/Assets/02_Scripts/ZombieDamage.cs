using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    private Animator an;
    [SerializeField]
    private GameObject BloodEffect;
    private CapsuleCollider CapCol;
    public float hp = 100f;
    public float hplmit = 100f;
    public static bool IsDie = false;

    void Start()
    {
        CapCol = GetComponent<CapsuleCollider>();
        an = GetComponent<Animator>();
        BloodEffect = Resources.Load<GameObject>("Effect/Blood");
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("BULLET"))
        {
            Destroy(col.gameObject); // col�� ������ ���� ���������
            GameObject blood = Instantiate(BloodEffect, col.transform.position, Quaternion.identity);
            Destroy(blood, 1.5f);
            an.SetTrigger("IsHit");
            hp = hp - 35f;
            if(hp <= 0)
                Die();
        }
        
    }
    void Die()
    {
        an.SetTrigger("IsDie");
        CapCol.enabled = false;
        //ĸ���ݶ��̴��� ��Ȱ��ȭ
        IsDie = true;
    }

}
