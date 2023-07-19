using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ����� ���̷����� �¾�� ����
// 1. ����� ���̷����� �������� �־����.
// 2. ����� ���̷����� �¾�� ��ġ.(SpawnPoint�� �����ص�)
// 3. ����� ���̷����� �� �� Ȥ�� �ð� �������� �¾���ϴ���
// - 3.1 ����� 3�� ���� ���� �¾��
// - 3.2 ���̷����� 5�� ���� ���� �¾��

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private Transform[] SpawnPoints; // []�� �迭�� �������� ������ �� ����.
    [SerializeField] private Text killTxt;
    public int Totalkill = 0;

    //     public static GameManager instance;
    // �̱��� ���
    // 1. public�̶�� ����� ������ �Լ��� ���� �����ϰ� �Ʒ� this��
    // 2. ���к��� ��ü ������ ���´�. ''�ѹ���'' �����ǰ� �Ѵ�.
    // ����Ƽ���� �̱��� ���
    // �Ŵ��� Ŭ������ ����ϰ� ��
    // �Ŵ��� Ŭ������ ���� ��ü�� �ƿ츦�� �־���ϱ� ������ ���� ������ �� �ְ��Ѵ�.
    // �ٸ� Ŭ�������� �����ϱ� �������.
    public static GameManager instance;

    private float timePrev1 = 0f; // �ð� ����
    private float timePrev2 = 0f; // �ð� ����
    private int maxCount = 5;

    void Start()
    {
        instance = this; // �ڱ��ڽ�(���ӸŴ��� Ŭ����)
        killTxt = GameObject.Find("Canvas_UI").transform.GetChild(1).GetChild(0).GetComponent<Text>();
        zombiePrefab = Resources.Load<GameObject>("ZomBie");
        skeletonPrefab = Resources.Load<GameObject>("Skeleton");
        SpawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>(); //SpawnPoints�� �������� ������Ʈ�̱⿡ ��������.
        timePrev1 = Time.time;
        timePrev2 = Time.time; // ����ð��� ������ �����Ͽ���.
    }

    void Update()
    {   // ����� - ���Ž� = �귯�� �ð�, ������ �ð����� ������ �ð��� ���� 3�ʰ� ���� ���
        if (Time.time - timePrev1 >= 3.0f)
        {
            int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            // ����ī��Ʈ�� ���̶�Ű���� ������ �±׸� ���� �͵��� ������ �Ѱ��ش�.
            if(zombieCount < maxCount)
            // �ƽ�ī��Ʈ�� 5�ε� �װź��� �۰ų� ���� ������ �Ʒ��� �۵���, �迭 ���̶� 0���� ������ ġ�⿡ �ϳ��� �� ���� �� ����
            CreateZombie();
            timePrev1 = Time.time; // �ٽ� �ݺ���. ��ŸƮ�� �ٽ� �ݺ���Ű�� ��.
        }
        if (Time.time - timePrev2 >= 5.0f)
        {
            int skelCount = (int)GameObject.FindGameObjectsWithTag("SKELETON").Length;
            if(skelCount < maxCount)
            CreateSkeleton();
            timePrev2 = Time.time; // �ٽ� �ݺ���.
        }
    }


    void CreateZombie()
    {                        // �迭�� �ι�°���� �迭 ���̰�����, ù��°�� SpanPoints�� ������ �ʹ� ����
        int idx = Random.Range(1,SpawnPoints.Length);
        Instantiate(zombiePrefab, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
           //������,  ������,     ��𿡼�(��ġ),             ���(�����̳� ȸ�� ��)
    }

    void CreateSkeleton()
    {                        // �迭�� �ι�°���� �迭 ���̰�����, ù��°�� SpanPoints�� ������ �ʹ� ����
        int idx = Random.Range(1, SpawnPoints.Length);
        Instantiate(skeletonPrefab, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
        //������,  ������,     ��𿡼�(��ġ),             ���(�����̳� ȸ�� ��)

    }
    public void KillScore(int score)
    {
        Totalkill += score;
        killTxt.text = "Kill : " + "<color=#ff0000>" + Totalkill.ToString() + "</color>";
    }
}
