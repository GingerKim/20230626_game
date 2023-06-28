using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ��ƼŬ(����Ʈ)
// 2. ����� �ҽ�
// 3. ����� Ŭ��

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
    // IsTrigger üũ �������� ����ϴ� ��
    //
    private void OnCollisionEnter(Collision col)
    {   // �浹ü(�Ѿ�)�� �±׸� �˻��Ѵ�(CompareTage).
        if(col.gameObject.CompareTag("BULLET"))
        {                         // ����(����ũ)��, spark�� �����̱⿡ spk�� �޾ƿ´�.
            Destroy(col.gameObject);
            GameObject spk = Instantiate(Spark, col.transform.position,Quaternion.identity);
            Destroy(spk, 3.0f); // ������ spk�� �������� �� �� �ִ�.
            source.PlayOneShot(sparkSound, 1.0f);
        }
    }
}
