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
    // 버튼에 마우스를 가져다 대면 버튼이 커짐
    // 버튼을 눌렀을 때 case별로 해당 동작을 수행하도록 만듦
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Newgame:
                SceneManager.LoadScene("TutorialStage1");
                break;
            case BTNType.Continue:
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
            case BTNType.Stage1Enter:
                SceneManager.LoadScene("Stage1_LevelScene");
                break;
            case BTNType.Stage2Enter:
                SceneManager.LoadScene("Stage2_LevelScene");
                break;
            case BTNType.Stage3Enter:
                SceneManager.LoadScene("Stage3_LevelScene");
                break;
            case BTNType.Stage4Enter:
                SceneManager.LoadScene("Stage4_LevelScene");
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
                }
                else
                {
                }
                isSound = !isSound;
                break;
            case BTNType.Back:
                SceneManager.LoadScene("MainScene");
                break;         
            case BTNType.Quit:
                Application.Quit();
                break;
            case BTNType.Stage1_Level1:
                SceneManager.LoadScene("LavaStage1");
                break;
            case BTNType.Stage1_Level2:
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage1_Level3:
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage1_Level4:
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage1_Level5:
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage1_Level6:
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage2_Level1:
                SceneManager.LoadScene("WaterStage1");
                break;
            case BTNType.Stage2_Level2:
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage2_Level3:
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage2_Level4:
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage2_Level5:
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage2_Level6:
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage3_Level1:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level2:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level3:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level4:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level5:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level6:
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage4_Level1:
                SceneManager.LoadScene("InfinityStorm4-1");
                break;
            case BTNType.Stage4_Level2:
                SceneManager.LoadScene("InfinityStorm4-2");
                break;
            case BTNType.Stage4_Level3:
                SceneManager.LoadScene("InfinityStorm4-3");
                break;
            case BTNType.Stage4_Level4:
                SceneManager.LoadScene("InfinityStorm4-3");
                break;
            case BTNType.Stage4_Level5:
                SceneManager.LoadScene("InfinityStorm4-3");
                break;
            case BTNType.Stage4_Level6:
                SceneManager.LoadScene("InfinityStorm4-3");
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
