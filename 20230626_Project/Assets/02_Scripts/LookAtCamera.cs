using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform MainCamera; // 메인카메라의 위치
    [SerializeField]
    private Transform CanvasTr; // 캔버스의 위치. 스크립트가 들어간 자기 자신임

    void Start()
    {                // 메인카메라의 위치
        MainCamera = Camera.main.transform;
        CanvasTr = GetComponent<Transform>();
    }

    void Update()
    {
        CanvasTr.LookAt(MainCamera); // 캔버스가 메인 카메라를 쳐다보다게 만드는 것.
    }
}
