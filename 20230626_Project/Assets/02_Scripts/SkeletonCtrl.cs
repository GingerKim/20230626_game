using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// 기억 안날땐 컴포넌트부터 채우자
// 필요한게 무엇이 있는지 알아야한다.
// 스켈레톤을 공격시키기 위해서는 애니메이션과 네비메쉬, 스켈레톤 위치, 플레이어 위치가 필요하기 때문에
// 아래와 같은 요소가 필요하다

public class SkeletonCtrl : MonoBehaviour
{
    private Animator anim;          // 움직이거나 공격할 애니메이션이 필요
    private NavMeshAgent agent;     // 네비로 찾아가야함
    private Transform skeletontr;   // 스켈레톤으로 공격을 가야하기 때문에 스켈레톤의 위치가 필요
    private Transform playertr;     // 플레이어를 공격해야 하기 때문에 플레이어의 위치가 필요
    public float attackDist = 3.5f;   // 해골이 칼로 공격하기 때문에 공격하기 위해서 또한 공격하려면 3.5 정도의 거리가 필요.
    public float traceDist = 15.0f;   // 해골이 플레이어를 쫒기 위해 인식하는거리
    
    void Start()
    {
        skeletontr = transform; // 스켈레톤에 할당된 스크립트이기 때문에 이렇게만 해도 된다.
        playertr = GameObject.FindWithTag("Player").transform; 
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (SkeletonDamage.IsDie) return;
        // 실시간으로 거리를 잰다.
        float dist = Vector3.Distance(playertr.position, skeletontr.position);
        if(dist < attackDist )
        {
            agent.isStopped = true;
            anim.SetBool("IsAttack", true);
        }
        else if(dist <= traceDist )
        {
            agent.isStopped = false;
            agent.destination = playertr.position;
            anim.SetBool("IsTrace", true);
            anim.SetBool("IsAttack", false);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("IsTrace", false);

        }
    }
}
