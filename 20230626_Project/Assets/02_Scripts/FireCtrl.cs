using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 총알 발사위치 정하기
// 2. 총알 프리펩 소환하기
// 3. 발사 사운드 재생하기

public class FireCtrl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePos;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip fireSound;

    void Start()
    {
        FirePos = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();
        bulletPrefab = (GameObject) Resources.Load("Bullet");  // 형 변환으로는 C언어 방식이고
        source = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot"); // 이 형 변환으로는 C++ 방식이다.
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼은 0임 휠버튼은 2 오른쪽 버튼은 1
        {
            Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
            // 프리펩을 생성한다.(what총알(bulletPrefab), where총알 포지션(FirePos.position), how, rotation총알 방향(FirePos.rotation))
            source.PlayOneShot(fireSound, 1.0f);
        }
    }
}
