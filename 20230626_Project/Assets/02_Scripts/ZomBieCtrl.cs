using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomBieCtrl : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public float traceDist = 15.0f; // 추적 거리
    [SerializeField]
    public float attackDist = 3.0f; // 공격 거리
    [SerializeField]
    private Transform playerTr; // 플레이어의 위치 

    void Start()
    {
        playerTr = GameObject.FindWithTag("Player").transform;
                // 하이어라키에서 Player라는 태그를 가진 오브젝트의 transform을 playerTr에 대입한다.
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()        
    {
        if (ZombieDamage.IsDie == true) return;
        // 좀비가 죽었다면 아래로 안내려가고 업데이트를 빠젹
        float dist = Vector3.Distance(transform.position, playerTr.position); // 거리를 잰다.
        if (dist <= attackDist) // 범위가 3 안에 들 경우
        {
            agent.isStopped = true; // 네비메쉬(agent)에 의한 추적을 중지
            animator.SetBool("IsAttack", true); // 애니메이터에 있는 IsAttack을 작동시킨다.
        }
        else if(dist <= traceDist)
        {
            agent.destination = playerTr.position;
            // 추적지, 목적지 = 플레이어의 포지션
            agent.isStopped = false;
            // 추적 시작
            animator.SetBool("IsTrace",true);
            animator.SetBool("IsAttack",false); // 이래야 walk로 이동하며 추적이 가능함.
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsTrace", false);
        }
    }
}
