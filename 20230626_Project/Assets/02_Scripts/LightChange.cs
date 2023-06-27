using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    [SerializeField] private Light whiteLight;
    [SerializeField] private Light blueLight;
    [SerializeField] private Light yellowLight;

    [SerializeField] private AudioClip lightOpenning;
    [SerializeField] private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        lightOpenning = Resources.Load<AudioClip>("LightOpenning");

        whiteLight = transform.GetChild(0).GetComponent<Light>(); // 첫번째 자식에게 Light 컴포넌트를 추가한다
        blueLight = transform.GetChild(1).GetComponent<Light>(); // 두번째 자식에게 Light 컴포넌트를 추가한다
        yellowLight = transform.GetChild(2).GetComponent<Light>(); // 세번째 자식에게 Light 컴포넌트를 추가한다
        TurnOn();
    }

    void TurnOn()
    {
        StartCoroutine(ShowLightchange()); // 턴온으로 ShowLightChange라는 스타트코루틴을 시작한다.
    }
    IEnumerator ShowLightchange()
    {
        // 화이트라이트만 켜짐
        whiteLight.enabled = true;
        blueLight.enabled = false;
        yellowLight.enabled = false;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);

        // 3초 후에는 블루라이트만 켜짐
        whiteLight.enabled = false;
        blueLight.enabled = true;
        yellowLight.enabled = false;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);

        // 3초 후에는 옐로우라이트만 켜짐
        whiteLight.enabled = false;
        blueLight.enabled = false;
        yellowLight.enabled = true;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);
        source.PlayOneShot(lightOpenning, 1.0f);
        TurnOn();
    }
}
