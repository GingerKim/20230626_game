using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomBieCtrl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public float traceDist = 15.0f; // ���� �Ÿ�
    public float attackDist = 3.0f; // ���� �Ÿ�
    private Transform playerTr; // �÷��̾��� ��ġ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, playerTr.position); // �Ÿ��� ���.
        if (attackDist <= 3.0f) // ���ù����� 3 �ȿ� �� ���
        {
            agent.isStopped = true; // �׺�޽�(agent)�� ���� ������ ����
            animator.SetBool("IsAttack", true); // �ִϸ����Ϳ� �ִ� IsAttack�� �۵���Ų��.
        }
        else if(traceDist <= 15.0f)
        {

        }
    }
}
