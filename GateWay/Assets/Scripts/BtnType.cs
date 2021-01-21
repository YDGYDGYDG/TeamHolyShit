using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    
    public GameObject mainUI;
    public GameObject credit;
    public bool creditON;

    bool isSound;
    public void Awake()
    {
        credit = GameObject.Find("Credit");
        defaultScale = buttonScale.localScale;
    }
    
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Newgame:
                SceneManager.LoadScene("Game");
                break;
            case BTNType.Continue:
                SceneManager.LoadScene("Game");
                break;
            case BTNType.Level:
                SceneManager.LoadScene("Game");
                break;
            case BTNType.Option:
                SceneManager.LoadScene("OptionScene");
                break;
            case BTNType.Credit:
                if (creditON)
                {
                    credit.SetActive(true);
                }
                else
                {
                    credit.SetActive(false);
                }
                creditON = !creditON;
                break;
            case BTNType.Sound:
                if (isSound)
                {
                    Debug.Log("사운드OFF");
                }
                else
                {
                    Debug.Log("사운드ON");
                }
                isSound = !isSound;
                break;
            case BTNType.Back:
                SceneManager.LoadScene("MainScene");
                break;           
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("앱종료");
                break;
        }

    }
  

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
