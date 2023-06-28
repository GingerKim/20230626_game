using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 파티클(이펙트)
// 2. 오디오 소스
// 3. 오디오 클립

public class ContainerCtrl : MonoBehaviour
{
    [SerializeField] private GameObject Spark;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sparkSound;

    void Start()
    {
        source = GetComponent<AudioSource>();
        sparkSound = Resources.Load("hit_metal") as AudioClip;
        Spark = Resources.Load<GameObject>("Effect/Spark");
    }
    // IsTrigger 체크 안했을때 사용하는 것
    //
    private void OnCollisionEnter(Collision col)
    {   // 충돌체(총알)의 태그를 검사한다(CompareTage).
        if(col.gameObject.CompareTag("BULLET"))
        {                         // 무엇(스파크)을, spark는 원본이기에 spk로 받아온다.
            Destroy(col.gameObject);
            GameObject spk = Instantiate(Spark, col.transform.position,Quaternion.identity);
            Destroy(spk, 3.0f); // 때문에 spk가 없어지게 할 수 있다.
            source.PlayOneShot(sparkSound, 1.0f);
        }
    }
}
