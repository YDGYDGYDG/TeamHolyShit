using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject menuSet;
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public bool isSound;
    public void Awake()
    {
        defaultScale = buttonScale.localScale;
    }
    
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Newgame:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Continue:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Level:
                SceneManager.LoadScene("StageSelectScene");
                break;
            case BTNType.Stage1:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage2:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage3:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage4:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Hidden:
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Option:
                SceneManager.LoadScene("OptionScene");
                break;
            case BTNType.Credit:              
                 SceneManager.LoadScene("CreditScene");                           
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
