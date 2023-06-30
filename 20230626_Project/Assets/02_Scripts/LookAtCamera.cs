using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform MainCamera; // ����ī�޶��� ��ġ
    [SerializeField]
    private Transform CanvasTr; // ĵ������ ��ġ. ��ũ��Ʈ�� �� �ڱ� �ڽ���

    void Start()
    {                // ����ī�޶��� ��ġ
        MainCamera = Camera.main.transform;
        CanvasTr = GetComponent<Transform>();
    }

    void Update()
    {
        CanvasTr.LookAt(MainCamera); // ĵ������ ���� ī�޶� �Ĵٺ��ٰ� ����� ��.
    }
}
