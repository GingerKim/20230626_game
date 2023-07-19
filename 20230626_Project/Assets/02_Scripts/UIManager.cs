using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor; // �����쿡�� ����Ƽ �����͸� ����� ���.

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text FinalKilltext;

    void Start()
    {
        FinalKilltext = GameObject.Find("Canvas_UI").transform.GetChild(2).GetChild(3).GetComponent<Text>();
        FinalKilltext.text = "Final Kill : " + "<color=#ff0000>" + GameManager.instance.Totalkill.ToString() + "</color>";
        // Ŀ���� ������ ���� ���̰� �ϱ�
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Ŀ�� �����
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("BattleFieldScene");
    }
    public void QuitGame()
    {   // ���α׷�, ������ �����Ҷ��� �� ���� ���Ḧ �ؾ��Ѵ�.
        // 1. ����Ƽ �÷��� ���¸� ����.
        // 2. ������ ���� ����.
    #if UNITY_EDITOR  // ����Ƽ ������(������)���� ������ ���
        EditorApplication.isPlaying = false; // UnityEditor�� �� ��� ��ܿ� using UnityEditor;�� �ٿ�����

#else
        Application.Quit();// ������ ���� ���� // ������ ���� ����
#endif
    }
}