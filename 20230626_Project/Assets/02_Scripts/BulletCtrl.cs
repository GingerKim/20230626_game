using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rd;
    [SerializeField]
    private CapsuleCollider capCol;
    [SerializeField]
    private float Speed = 2500.0f;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        capCol = rd.GetComponent<CapsuleCollider>();
        rd.AddForce(transform.forward * Speed); // Vector3는 쓰면 안된다. transform을 써야한다.
                                                // 안그러면 한쪽으로만 쏜다.
                                                // 트랜스폼은 로컬임, 엑셀레이션은 가속이고 임펄스는 점프할때 쓰고
                                                // 벨로시티체인지는 유도탄처럼 위치가 바뀔때 씀
                                                // Velocity는 힘과 방향임. 이것을 벨로시티라고 함(방향과 힘도 해당)
        Destroy(gameObject, 3.0f);
        // 소멸함수(오브젝트(자기자신),  시간)

    }
}
