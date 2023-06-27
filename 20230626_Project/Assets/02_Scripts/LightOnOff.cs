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
    // 콜라이더가 isTrigger로 닿았을때 호출하는 콜백 함수 OnTriggerEnter
    // 즉 내가 호출하지 않아도 충돌하면 스스로 호출하는 것이 콜백함수
    //충돌한 충돌체의 태그가 Playerd인 경우 stairLight를 enable한다.
    private void OnTriggerEnter(Collider other)
    {
        #region 스트링이 문자열이라 메모리가 무거워진다.
        //if (other.gameObject.tag == "Player") // Collider인 other의 tag를 Player로 적용
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

    //충돌한 충돌체의 태그가 Playerd인 경우 stairLight를 disable한다.
    private void OnTriggerExit(Collider other) 
    {
        #region 스트링이 문자열이라 메모리가 무거워진다.
        //if (other.gameObject.tag == "Player") // Collider인 other의 tag를 Player로 적용
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
