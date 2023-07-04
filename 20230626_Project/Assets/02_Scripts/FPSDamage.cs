using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ������ ���
using Unity.VisualScripting;

public class FPSDamage : MonoBehaviour
{
    [SerializeField]private Image hpBar; // ü�¹�
    [SerializeField]private GameObject killCanvas; // �׾����� ���� ȭ��
    private float hp; // ü��
    private float hpinit = 100f; //ü��ġ
    
    void Start()
    {
        killCanvas = GameObject.Find("Canvas_UI").transform.GetChild(2).gameObject;
        // ���� ȣ���� ��� ��Ȱ��ȭ �� �༮�� ã���� ���� ���� �ʴ´�. ������ ü�¹ٰ� ���� �ʴ� ���� ���� �߻���.
        // �ݸ� �̷��� ���ڴ�� ã�� �� �༮�� ã���� �ְ� �ȴ�.
        hpBar = GameObject.Find("Canvas_UI").transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>();
        // ���̾��Ű���� ������Ʈ(�̸�)�� ã�´�. �� ������, �� ������ ������Ʈ�� ã�´�
        hp = hpinit; // hp�� 100��
        hpBar.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PUNCH"))
        {
            hp -= 15f;
            hp = Mathf.Clamp(hp, 0f, 100f); // hp�� ������ ����������.
            hpBar.fillAmount = hp / hpinit;

        }
        if(other.gameObject.CompareTag("SWORD"))
        {
            hp -= 25f;
            hp = Mathf.Clamp(hp, 0f, 100f); // hp�� ������ ����������.
            hpBar.fillAmount = hp / hpinit;
        }

        if (hp <= 0f)
            PlayerDie();
    }
    void PlayerDie()
    {
        Debug.Log("�÷��̾� ���!");
        killCanvas.SetActive(true); // ������Ʈ�� �Ҵ�.
        Invoke("EndScene", 3.0f);
    }
    void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
