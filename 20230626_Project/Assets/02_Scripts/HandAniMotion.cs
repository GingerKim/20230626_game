using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 달릴 때 총을 접는다.
// 2. 달리다 멈추면 다시 총을 겨눈다.

public class HandAniMotion : MonoBehaviour
{
    [SerializeField] // private라도 인스펙터에 보임
    private Animation CombatSg;

    void Start()
    {
        CombatSg = transform.GetChild(0).GetChild(0).GetComponent<Animation>();
        
    }
    void Update()
    {   // if 왼쪽 쉬프트키와 w키를 동시에 눌렀다면
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            CombatSg.Play("running");
        }
        // else if 왼쪽 쉬프트키에서 손을 떼었다면
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CombatSg.Play("runStop");
        } 
    }
}
