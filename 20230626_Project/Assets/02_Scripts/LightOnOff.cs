using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    [SerializeField] private Light       stairLight;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip   lightSound;
 
    void Start()
    {
        stairLight = GetComponent<Light>();
        source     = GetComponent<AudioSource>();
        lightSound = Resources.Load<AudioClip>("LightSound");
    }
    // �ݶ��̴��� isTrigger�� ������� ȣ���ϴ� �ݹ� �Լ� OnTriggerEnter
    // �� ���� ȣ������ �ʾƵ� �浹�ϸ� ������ ȣ���ϴ� ���� �ݹ��Լ�
    //�浹�� �浹ü�� �±װ� Playerd�� ��� stairLight�� enable�Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        #region ��Ʈ���� ���ڿ��̶� �޸𸮰� ���ſ�����.
        //if (other.gameObject.tag == "Player") // Collider�� other�� tag�� Player�� ����
        //{
        //    stairLight.enabled = true;
        //}
        #endregion
        if(other.gameObject.CompareTag("Player"))
        {
            stairLight.enabled = true;
        }
        source.PlayOneShot(lightSound, 1.0f);
    }

    //�浹�� �浹ü�� �±װ� Playerd�� ��� stairLight�� disable�Ѵ�.
    private void OnTriggerExit(Collider other) 
    {
        #region ��Ʈ���� ���ڿ��̶� �޸𸮰� ���ſ�����.
        //if (other.gameObject.tag == "Player") // Collider�� other�� tag�� Player�� ����
        //{
        //    stairLight.enabled = false;
        //}
        #endregion
        if (other.gameObject.CompareTag("Player"))
        {
            stairLight.enabled = false;
        }
        source.PlayOneShot(lightSound, 1.0f);
    }

}
