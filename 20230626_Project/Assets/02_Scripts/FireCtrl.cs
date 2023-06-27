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

    void Start()
    {
        FirePos = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<Transform>();
        bulletPrefab = (GameObject) Resources.Load("Bullet");  // �� ��ȯ���δ� C��� ����̰�
        source = GetComponent<AudioSource>();
        fireSound = Resources.Load<AudioClip>("gunShot"); // �� �� ��ȯ���δ� C++ ����̴�.
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� 0�� �ٹ�ư�� 2 ������ ��ư�� 1
        {
            Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
            // �������� �����Ѵ�.(what�Ѿ�(bulletPrefab), where�Ѿ� ������(FirePos.position), how, rotation�Ѿ� ����(FirePos.rotation))
            source.PlayOneShot(fireSound, 1.0f);
        }
    }
}
