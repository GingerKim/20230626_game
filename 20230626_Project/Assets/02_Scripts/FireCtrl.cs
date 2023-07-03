using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. �Ѿ� �߻���ġ ���ϱ�
// 2. �Ѿ� ������ ��ȯ�ϱ�
// 3. �߻� ���� ����ϱ�

public class FireCtrl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePos;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private ParticleSystem CartridgeEjectEffect;
    [SerializeField] private Animation Ani;

    private bool isReload = false; // �翬�� �������� �Ϸ��� 0�� �Ǿ���ϴµ� ó���� ������ �����ϼ��� ����.
    // �ش� ������ �߿伺�� �� �� ���� ex) �ִϸ��̼� ���·� ����
    public int bulletCount = 0; // �Ҹ��� ī��Ʈ Ƚ���� 0���� ������
    // �������� Ŭ������ ȣ���� �����ϴ�.
    // ���ÿ���(��������, �Ű�����), ������(�ѹ� ȣ��Ǹ� ���������), �����Ϳ���(����static�� �Ǵµ� ���α׷��� ����ɶ����� ���´�) 
    // ������Ʈ, �ڽ�, ��ڽ��� �߿���.
    void Start()
    {
        Ani = transform.GetChild(0).GetChild(0).GetComponent<Animation>();
        FirePos = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();
        MuzzleFlash = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(0).GetComponent<ParticleSystem>();
        CartridgeEjectEffect = transform.GetChild(0).GetChild(0).GetChild(5).GetChild(1).GetComponent<ParticleSystem>();
        bulletPrefab = (GameObject)Resources.Load("Bullet");  // �� ��ȯ���δ� C��� ����̰�
        source = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot"); // �� �� ��ȯ���δ� C++ ����̴�.
    }

    void Update()
    {
        if(isReload == false)
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� 0�� �ٹ�ư�� 2 ������ ��ư�� 1
        {   // Statcic ������ �Ʒ��� ���� Ŭ������(HandAniMotion). ������(isRunning)���� ȣ���� �����ϴ�
            if (!HandAniMotion.isRunning) // �޸��� ���� ��쿡 �Ʒ��� ���� �۵��Ѵ�. ����ǥ�� �ٿ��� false�� ǥ���� ���ִ�.
                                          // if (HandAniMotion.isRunning == false) // �޸��� ���� ��쿡 �Ʒ��� ���� �۵��Ѵ�.
            {
                Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
                // �������� �����Ѵ�.(what�Ѿ�(bulletPrefab), where�Ѿ� ������(FirePos.position), how, rotation�Ѿ� ����(FirePos.rotation))
                source.PlayOneShot(fireSound, 1.0f);
                MuzzleFlash.Play();
                CartridgeEjectEffect.Play();
                Ani.Play("fire");
                bulletCount++; // ���� ������ ī��Ʈ�� 1�� �þ
                if (bulletCount == 10) // ī��Ʈ�� 10�� �� ���
                {   // ��ŸƮ�ڷ�ƾ�� ���۵�
                    StartCoroutine(ShowReloading());
                }
            }

        }
        else if (Input.GetMouseButtonUp(0)) // ���� ���콺 ��ư�� ������ �����ٸ�
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
