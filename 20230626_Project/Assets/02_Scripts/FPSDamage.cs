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
        // 하이어라키에서 오브젝트(이름)을 찾는다. 그 하위의, 그 하위의 컴포넌트를 찾는다
        hp = hpinit; // hp는 100임
        hpBar.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PUNCH"))
        {
            hp -= 15f;
            hp = Mathf.Clamp(hp, 0f, 100f); // hp의 범위를 한정시켜줌.
            hpBar.fillAmount = hp / hpinit;

        }
        if(other.gameObject.CompareTag("SWORD"))
        {
            hp -= 25f;
            hp = Mathf.Clamp(hp, 0f, 100f); // hp의 범위를 한정시켜줌.
            hpBar.fillAmount = hp / hpinit;
        }

        if (hp <= 0f)
            PlayerDie();
    }
    void PlayerDie()
    {
        Debug.Log("플레이어 사망!");
    }
}
