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
    public float traceDist = 15.0f; // ���� �Ÿ�
    [SerializeField]
    public float attackDist = 3.0f; // ���� �Ÿ�
    [SerializeField]
    private Transform playerTr; // �÷��̾��� ��ġ 

    void Start()
    {
        playerTr = GameObject.FindWithTag("Player").transform;
                // ���̾��Ű���� Player��� �±׸� ���� ������Ʈ�� transform�� playerTr�� �����Ѵ�.
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()        
    {
        if (ZombieDamage.IsDie == true) return;
        // ���� �׾��ٸ� �Ʒ��� �ȳ������� ������Ʈ�� ����
        float dist = Vector3.Distance(transform.position, playerTr.position); // �Ÿ��� ���.
        if (dist <= attackDist) // ������ 3 �ȿ� �� ���
        {
            agent.isStopped = true; // �׺�޽�(agent)�� ���� ������ ����
            animator.SetBool("IsAttack", true); // �ִϸ����Ϳ� �ִ� IsAttack�� �۵���Ų��.
        }
        else if(dist <= traceDist)
        {
            agent.destination = playerTr.position;
            // ������, ������ = �÷��̾��� ������
            agent.isStopped = false;
            // ���� ����
            animator.SetBool("IsTrace",true);
            animator.SetBool("IsAttack",false); // �̷��� walk�� �̵��ϸ� ������ ������.
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsTrace", false);
        }
    }
}
