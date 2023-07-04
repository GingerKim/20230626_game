using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor; // 윈도우에서 유니티 에디터를 사용할 경우.

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text FinalKilltext;

    void Start()
    {
        FinalKilltext = GameObject.Find("Canvas_UI").transform.GetChild(2).GetChild(3).GetComponent<Text>();
        FinalKilltext.text = "Final Kill : " + "<color=#ff0000>" + GameManager.instance.Totalkill.ToString() + "</color>";
        // 커서가 숨겨진 것을 보이게 하기
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // 커서 숨기기
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("BattleFieldScene");
    }
    public void QuitGame()
    {   // 프로그램, 어플을 종료할때는 두 가지 종료를 해야한다.
        // 1. 유니티 플레이 상태를 종료.
        // 2. 빌드한 것을 종료.
    #if UNITY_EDITOR  // 유니티 에디터(윈도우)에서 종료할 경우
        EditorApplication.isPlaying = false; // UnityEditor를 뗼 경우 상단에 using UnityEditor;를 붙여야함

#else
        Application.Quit();// 빌드한 것을 종료 // 빌드한 것을 종료
#endif
    }
}