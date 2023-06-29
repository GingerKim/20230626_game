using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamage : MonoBehaviour
{
    private Animator Anima;
    [SerializeField]
    private CapsuleCollider CapCol;
    public float hp = 50f;
    public float hplmit = 50f;
    public static bool IsDie = false;


    void Start()
    {
        CapCol = GetComponent<CapsuleCollider>();
        Anima = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("BULLET"))
        {
            Destroy(col.gameObject); // 좀비가 아닌 총알을 없애려면 col을 붙여야함
            Anima.SetTrigger("IsHit");
            hp = hp - 35f;
            if (hp <= 0)
                Die();
        }
    }

    void Die()
    {
        Anima.SetTrigger("IsDie");
        GetComponent<Rigidbody>().isKinematic = true;
        CapCol.enabled = false;
        IsDie = true;
        // 죽었을때 물리 현상이 없게 만든다.
    }


}
