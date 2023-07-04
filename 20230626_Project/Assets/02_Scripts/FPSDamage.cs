using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 씬관련 기능
using Unity.VisualScripting;

public class FPSDamage : MonoBehaviour
{
    [SerializeField]private Image hpBar; // 체력바
    [SerializeField]private GameObject killCanvas; // 죽었을때 나올 화면
    private float hp; // 체력
    private float hpinit = 100f; //체력치
    
    void Start()
    {
        killCanvas = GameObject.Find("Canvas_UI").transform.GetChild(2).gameObject;
        // 직접 호출할 경우 비활성화 된 녀석은 찾을수 없어 뜨지 않는다. 때문에 체력바가 뜨지 않는 문제 등이 발생함.
        // 반면 이렇게 숫자대로 찾게 된 녀석은 찾을수 있게 된다.
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
        killCanvas.SetActive(true); // 오브젝트를 켠다.
        Invoke("EndScene", 3.0f);
    }
    void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
