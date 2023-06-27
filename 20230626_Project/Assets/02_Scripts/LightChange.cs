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

        whiteLight = transform.GetChild(0).GetComponent<Light>(); // ù��° �ڽĿ��� Light ������Ʈ�� �߰��Ѵ�
        blueLight = transform.GetChild(1).GetComponent<Light>(); // �ι�° �ڽĿ��� Light ������Ʈ�� �߰��Ѵ�
        yellowLight = transform.GetChild(2).GetComponent<Light>(); // ����° �ڽĿ��� Light ������Ʈ�� �߰��Ѵ�
        TurnOn();
    }

    void TurnOn()
    {
        StartCoroutine(ShowLightchange()); // �Ͽ����� ShowLightChange��� ��ŸƮ�ڷ�ƾ�� �����Ѵ�.
    }
    IEnumerator ShowLightchange()
    {
        // ȭ��Ʈ����Ʈ�� ����
        whiteLight.enabled = true;
        blueLight.enabled = false;
        yellowLight.enabled = false;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);

        // 3�� �Ŀ��� ������Ʈ�� ����
        whiteLight.enabled = false;
        blueLight.enabled = true;
        yellowLight.enabled = false;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);

        // 3�� �Ŀ��� ���ο����Ʈ�� ����
        whiteLight.enabled = false;
        blueLight.enabled = false;
        yellowLight.enabled = true;
        source.PlayOneShot(lightOpenning, 1.0f);
        yield return new WaitForSeconds(3f);
        source.PlayOneShot(lightOpenning, 1.0f);
        TurnOn();
    }
}
