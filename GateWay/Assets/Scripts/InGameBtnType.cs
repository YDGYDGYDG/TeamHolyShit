using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameBtnType : MonoBehaviour
{
    public InGameBTNType InGameBtn;
    public GameObject menuSet;

    public void InGameOnBtnClick()
    {
        switch (InGameBtn)
        {
            case InGameBTNType.GameContinue:
                menuSet.SetActive(false);
                break;
            case InGameBTNType.GameSave:
                Debug.Log("게임세이브");
                SceneManager.LoadScene("MainScene");
                break; 
            case InGameBTNType.GameQuit:
                Application.Quit();
                Debug.Log("앱종료");            
                break;
            case InGameBTNType.Xbtn:
                if (menuSet.activeSelf)
                    menuSet.SetActive(false);
                else
                    menuSet.SetActive(true);
                break;
            case InGameBTNType.Reset:
                Debug.Log("세이브포인트로 이동");
                break;
        }

    }
}
