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
                Debug.Log("위치저장");
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
                Debug.Log("최근Save포인트로 이동");
                break;
        }

    }
}
