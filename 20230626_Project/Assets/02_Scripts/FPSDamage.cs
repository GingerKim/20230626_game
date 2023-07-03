using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDamage : MonoBehaviour
{
    [SerializeField]
    private Image hpBar;
    private float hp;
    private float hpinit = 100f;
    
    void Start()
    {
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
    }
}
