using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// ��� �ȳ��� ������Ʈ���� ä����
// �ʿ��Ѱ� ������ �ִ��� �˾ƾ��Ѵ�.
// ���̷����� ���ݽ�Ű�� ���ؼ��� �ִϸ��̼ǰ� �׺�޽�, ���̷��� ��ġ, �÷��̾� ��ġ�� �ʿ��ϱ� ������
// �Ʒ��� ���� ��Ұ� �ʿ��ϴ�

public class SkeletonCtrl : MonoBehaviour
{
    private Animator anim;          // �����̰ų� ������ �ִϸ��̼��� �ʿ�
    private NavMeshAgent agent;     // �׺�� ã�ư�����
    private Transform skeletontr;   // ���̷������� ������ �����ϱ� ������ ���̷����� ��ġ�� �ʿ�
    private Transform playertr;     // �÷��̾ �����ؾ� �ϱ� ������ �÷��̾��� ��ġ�� �ʿ�
    public float attackDist = 3.5f;   // �ذ��� Į�� �����ϱ� ������ �����ϱ� ���ؼ� ���� �����Ϸ��� 3.5 ������ �Ÿ��� �ʿ�.
    public float traceDist = 15.0f;   // �ذ��� �÷��̾ �i�� ���� �ν��ϴ°Ÿ�
    
    void Start()
    {
        skeletontr = transform; // ���̷��濡 �Ҵ�� ��ũ��Ʈ�̱� ������ �̷��Ը� �ص� �ȴ�.
        playertr = GameObject.FindWithTag("Player").transform; 
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (SkeletonDamage.IsDie) return;
        // �ǽð����� �Ÿ��� ���.
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
