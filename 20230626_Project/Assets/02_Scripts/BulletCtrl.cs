using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rd;
    [SerializeField]
    private CapsuleCollider capCol;
    [SerializeField]
    private float Speed = 2500.0f;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        capCol = rd.GetComponent<CapsuleCollider>();
        rd.AddForce(transform.forward * Speed); // Vector3�� ���� �ȵȴ�. transform�� ����Ѵ�.
                                                // �ȱ׷��� �������θ� ���.
                                                // Ʈ�������� ������, �������̼��� �����̰� ���޽��� �����Ҷ� ����
                                                // ���ν�Ƽü������ ����źó�� ��ġ�� �ٲ� ��
                                                // Velocity�� ���� ������. �̰��� ���ν�Ƽ��� ��(����� ���� �ش�)
        Destroy(gameObject, 3.0f);
        // �Ҹ��Լ�(������Ʈ(�ڱ��ڽ�),  �ð�)

    }
}
