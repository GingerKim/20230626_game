using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomBieCtrl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public float traceDist = 15.0f; // 추적 거리
    public float attackDist = 3.0f; // 공격 거리
    private Transform playerTr; // 플레이어의 위치

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, playerTr.position); // 거리를 잰다.
        if (attackDist <= 3.0f) // 어택범위가 3 안에 들 경우
        {
            agent.isStopped = true; // 네비메쉬(agent)에 의한 추적을 중지
            animator.SetBool("IsAttack", true); // 애니메이터에 있는 IsAttack을 작동시킨다.
        }
        else if(traceDist <= 15.0f)
        {

        }
    }
}
