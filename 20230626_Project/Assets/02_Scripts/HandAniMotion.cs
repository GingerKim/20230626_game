using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �޸� �� ���� ���´�.
// 2. �޸��� ���߸� �ٽ� ���� �ܴ���.

public class HandAniMotion : MonoBehaviour
{
    [SerializeField] // private�� �ν����Ϳ� ����
    private Animation CombatSg;
    public static bool isRunning = false;
              // �޸��� �ִ� ������ �ƴ��� �Ǵ�
              // static�� ����������. ������ �� ����, ��ü�� Ŭ�������� ������ �����ϴ�
              // ���� �޸𸮰� �̸� �Ҵ�ȴ�. ������ ���α׷� ����ñ��� 

    void Start()
    {
        CombatSg = transform.GetChild(0).GetChild(0).GetComponent<Animation>();
        
    }
    void Update()
    {   // if ���� ����ƮŰ�� wŰ�� ���ÿ� �����ٸ�
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            CombatSg.Play("running");
            isRunning = true; // �޸��� ��
        }
        // else if ���� ����ƮŰ���� ���� �����ٸ�
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CombatSg.Play("runStop");
            isRunning = false; // �޸��� �ʴ� ��
        } 
    }
}
