using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// IngameUI 스크립트와 연동되어있음
// 위치 저장
// 위치로 이동
// 인게임내 버튼을 눌렀을때의 행동들이 정의되어 있음

public class InGameBtnType : MonoBehaviour
{
    public InGameBTNType InGameBtn;
    public GameObject menuSet;
    public GameObject Player;
   
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        Player.transform.position = new Vector3(x, y, 0);
    }
    public void InGameOnBtnClick()
    {
        switch (InGameBtn)
        {
            case InGameBTNType.GameContinue:
                menuSet.SetActive(false);
                break;
            case InGameBTNType.GameSave:
                GameSave();
                break; 
            case InGameBTNType.GameQuit:
                SceneManager.LoadScene("MainScene");
                break;
            case InGameBTNType.Xbtn:
                if (menuSet.activeSelf)
                    menuSet.SetActive(false);
                else
                    menuSet.SetActive(true);
                break;
            case InGameBTNType.Reset:
                GameLoad();
                break;
        }

    }
}
