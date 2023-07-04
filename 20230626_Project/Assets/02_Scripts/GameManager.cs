using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 좀비와 스켈레톤이 태어나는 로직
// 1. 좀비와 스켈레톤의 프리펩이 있어야함.
// 2. 좀비와 스켈레톤이 태어나는 위치.(SpawnPoint로 지정해둠)
// 3. 좀비와 스켈레톤이 몇 초 혹은 시간 간격으로 태어나야하는지
// - 3.1 좀비는 3초 간격 마다 태어난다
// - 3.2 스켈레톤은 5초 간격 마다 태어난다

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private Transform[] SpawnPoints; // []는 배열로 여러개를 저장할 수 있음.
    [SerializeField] private Text killTxt;
    public int Totalkill = 0;

    //     public static GameManager instance;
    // 싱글톤 사용
    // 1. public이라고 선언된 변수나 함수에 쉽게 접근하게 아래 this로
    // 2. 무분별한 객체 생성을 막는다. ''한번만'' 생성되게 한다.
    // 유니티에서 싱글턴 사용
    // 매니저 클래스에 사용하게 됨
    // 매니저 클래스는 게임 전체를 아우를수 있어야하기 때문에 쉽게 접근할 수 있게한다.
    // 다른 클래스에서 접근하기 쉬어야함.
    public static GameManager instance;

    private float timePrev1 = 0f; // 시간 간격
    private float timePrev2 = 0f; // 시간 간격
    private int maxCount = 5;

    void Start()
    {
        instance = this; // 자기자신(게임매니저 클래스)
        killTxt = GameObject.Find("Canvas_UI").transform.GetChild(1).GetChild(0).GetComponent<Text>();
        zombiePrefab = Resources.Load<GameObject>("ZomBie");
        skeletonPrefab = Resources.Load<GameObject>("Skeleton");
        SpawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>(); //SpawnPoints의 여러가지 컴포넌트이기에 복수형임.
        timePrev1 = Time.time;
        timePrev2 = Time.time; // 현재시간을 변수에 대입하였음.
    }

    void Update()
    {   // 현재시 - 과거시 = 흘러간 시간, 현재의 시간에서 과거의 시간을 뺀게 3초가 지날 경우
        if (Time.time - timePrev1 >= 3.0f)
        {
            int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            // 좀비카운트에 하이라키에서 좀비라는 태그를 가진 것들의 갯수를 넘겨준다.
            if(zombieCount < maxCount)
            // 맥스카운트가 5인데 그거보다 작거나 같을 경우까지 아래로 작동함, 배열 값이라 0부터 갯수를 치기에 하나가 더 나올 수 있음
            CreateZombie();
            timePrev1 = Time.time; // 다시 반복함. 스타트를 다시 반복시키는 것.
        }
        if (Time.time - timePrev2 >= 5.0f)
        {
            int skelCount = (int)GameObject.FindGameObjectsWithTag("SKELETON").Length;
            if(skelCount < maxCount)
            CreateSkeleton();
            timePrev2 = Time.time; // 다시 반복함.
        }
    }


    void CreateZombie()
    {                        // 배열의 두번째부터 배열 길이값까지, 첫번째는 SpanPoints라 범위가 너무 넓음
        int idx = Random.Range(1,SpawnPoints.Length);
        Instantiate(zombiePrefab, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
           //만들어내다,  무엇을,     어디에서(위치),             어떻게(방향이나 회전 등)
    }

    void CreateSkeleton()
    {                        // 배열의 두번째부터 배열 길이값까지, 첫번째는 SpanPoints라 범위가 너무 넓음
        int idx = Random.Range(1, SpawnPoints.Length);
        Instantiate(skeletonPrefab, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
        //만들어내다,  무엇을,     어디에서(위치),             어떻게(방향이나 회전 등)

    }
    public void KillScore(int score)
    {
        Totalkill += score;
        killTxt.text = "Kill : " + "<color=#ff0000>" + Totalkill.ToString() + "</color>";
    }
}
