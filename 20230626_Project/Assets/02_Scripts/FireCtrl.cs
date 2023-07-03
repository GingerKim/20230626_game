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
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private ParticleSystem CartridgeEjectEffect;
    [SerializeField] private Animation Ani;

    private bool isReload = false; // 당연히 재장전을 하려면 0이 되어야하는데 처음엔 재장전 상태일수가 없음.
    // 해당 상태의 중요성을 알 수 있음 ex) 애니메이션 상태로 구분
    public int bulletCount = 0; // 불릿의 카운트 횟수를 0으로 시작함
    // 전역으로 클래스명 호출이 가능하다.
    // 스택영역(지역변수, 매개변수), 힙영역(한번 호출되면 사라져버림), 데이터영역(전역static이 되는데 프로그램이 종료될때까지 남는다) 
    // 오브젝트, 박싱, 언박싱이 중요함.
    void Start()
    {
        Ani = transform.GetChild(0).GetChild(0).GetComponent<Animation>();
        FirePos = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();
        MuzzleFlash = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<ParticleSystem>();
        CartridgeEjectEffect = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<ParticleSystem>();
        bulletPrefab = (GameObject)Resources.Load("Bullet");  // 형 변환으로는 C언어 방식이고
        source = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot"); // 이 형 변환으로는 C++ 방식이다.
    }

    void Update()
    {
        if(isReload == false)
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼은 0임 휠버튼은 2 오른쪽 버튼은 1
        {   // Statcic 변수라서 아래와 같이 클래스명(HandAniMotion). 변수명(isRunning)으로 호출이 가능하다
            if (!HandAniMotion.isRunning) // 달리지 않을 경우에 아래와 같이 작동한다. 느낌표를 붙여서 false로 표현할 수있다.
                                          // if (HandAniMotion.isRunning == false) // 달리지 않을 경우에 아래와 같이 작동한다.
            {
                Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
                // 프리펩을 생성한다.(what총알(bulletPrefab), where총알 포지션(FirePos.position), how, rotation총알 방향(FirePos.rotation))
                source.PlayOneShot(fireSound, 1.0f);
                MuzzleFlash.Play();
                CartridgeEjectEffect.Play();
                Ani.Play("fire");
                bulletCount++; // 총이 쏴지면 카운트가 1씩 늘어남
                if (bulletCount == 10) // 카운트가 10이 될 경우
                {   // 스타트코루틴이 시작됨
                    StartCoroutine(ShowReloading());
                }
            }

        }
        else if (Input.GetMouseButtonUp(0)) // 왼쪽 마우스 버튼을 눌렀다 떼었다면
        {
            MuzzleFlash.Stop();
            CartridgeEjectEffect.Stop();
        }
    }
    IEnumerator ShowReloading()
    {
        isReload = true;
        Ani.Play("pump3");
        yield return new WaitForSeconds(1f);
        isReload = false;
        bulletCount = 0;
    }

}
