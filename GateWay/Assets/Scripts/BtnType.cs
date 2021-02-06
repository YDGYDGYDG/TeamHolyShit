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
    public bool isButtonSound;

    AudioSource audioSource;        // 오디오 소스(형준)
    GameObject uiSE;                // 오디오 매니저(형준)
    GameObject uiBGM;
    MainUIsound mainUIsound;        // 오디오 매니저 스크립트(형준)
    public void Awake()
    {
        defaultScale = buttonScale.localScale;

        uiSE = GameObject.Find("UI SE");   // 오디오 매니저 연결(형준)
        uiBGM = GameObject.Find("UI BGM");   // 오디오 매니저 연결(형준)
        audioSource = uiSE.GetComponent<AudioSource>(); // 오디오 소스 연결(형준)
        mainUIsound = uiSE.GetComponent<MainUIsound>(); // 오디오 매니저 스크립트 연결(형준)
    }

    // 버튼에 마우스를 가져다 대면 버튼이 커짐
    // 버튼을 눌렀을 때 case별로 해당 동작을 수행하도록 만듦
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Newgame:
                btnClick();
                SceneManager.LoadScene("TutorialStage1");
                break;
            case BTNType.Continue:
                break;
            case BTNType.Level:
                btnClick();
                SceneManager.LoadScene("StageSelectScene");
                break;
            case BTNType.Stage1:
                btnClick();
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage2:
                btnClick();
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage3:
                btnClick();
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage4:
                btnClick();
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Stage1Enter:
                btnClick();
                SceneManager.LoadScene("Stage1_LevelScene");
                break;
            case BTNType.Stage2Enter:
                btnClick();
                SceneManager.LoadScene("Stage2_LevelScene");
                break;
            case BTNType.Stage3Enter:
                btnClick();
                SceneManager.LoadScene("Stage3_LevelScene");
                break;
            case BTNType.Stage4Enter:
                btnClick();
                SceneManager.LoadScene("Stage4_LevelScene");
                break;
            case BTNType.Hidden:
                btnClick();
                SceneManager.LoadScene("Tutorial1");
                break;
            case BTNType.Option:
                btnClick();
                SceneManager.LoadScene("OptionScene");
                break;
            case BTNType.Credit:
                btnClick();
                SceneManager.LoadScene("CreditScene");
                break;
            case BTNType.Sound:
                btnClick();    
                break;
            case BTNType.Back:
                btnClick();
                SceneManager.LoadScene("MainScene");
                break;         
            case BTNType.Quit:
                btnClick();
                Application.Quit();
                break;
            case BTNType.Stage1_Level1:
                btnClick();
                SceneManager.LoadScene("LavaStage1");
                break;
            case BTNType.Stage1_Level2:
                btnClick();
                SceneManager.LoadScene("LavaStage2");
                break;
            case BTNType.Stage1_Level3:
                btnClick();
                SceneManager.LoadScene("LavaStage3");
                break;
            case BTNType.Stage1_Level4:
                btnClick();
                SceneManager.LoadScene("LavaStage4");
                break;
            case BTNType.Stage1_Level5:
                btnClick();
                SceneManager.LoadScene("LavaStage5");
                break;
            case BTNType.Stage1_Level6:
                btnClick();
                SceneManager.LoadScene("LavaStage6");
                break;
            case BTNType.Stage2_Level1:
                btnClick();
                SceneManager.LoadScene("WaterStage1");
                break;
            case BTNType.Stage2_Level2:
                btnClick();
                SceneManager.LoadScene("WaterStage2");
                break;
            case BTNType.Stage2_Level3:
                btnClick();
                SceneManager.LoadScene("WaterStage3");
                break;
            case BTNType.Stage2_Level4:
                btnClick();
                SceneManager.LoadScene("WaterStage4");
                break;
            case BTNType.Stage2_Level5:
                btnClick();
                SceneManager.LoadScene("WaterStage5");
                break;
            case BTNType.Stage2_Level6:
                btnClick();
                SceneManager.LoadScene("WaterStage6");
                break;
            case BTNType.Stage3_Level1:
                btnClick();
                SceneManager.LoadScene("MachineryStage1");
                break;
            case BTNType.Stage3_Level2:
                btnClick();
                SceneManager.LoadScene("MachineryStage2");
                break;
            case BTNType.Stage3_Level3:
                btnClick();
                SceneManager.LoadScene("MachineryStage3");
                break;
            case BTNType.Stage3_Level4:
                btnClick();
                SceneManager.LoadScene("MachineryStage4");
                break;
            case BTNType.Stage3_Level5:
                btnClick();
                SceneManager.LoadScene("MachineryStage5");
                break;
            case BTNType.Stage3_Level6:
                btnClick();
                SceneManager.LoadScene("MachineryStage6");
                break;
            case BTNType.Stage4_Level1:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-1");
                break;
            case BTNType.Stage4_Level2:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-2");
                break;
            case BTNType.Stage4_Level3:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-3");
                break;
            case BTNType.Stage4_Level4:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-4");
                break;
            case BTNType.Stage4_Level5:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-5");
                break;
            case BTNType.Stage4_Level6:
                btnClick();
                SceneManager.LoadScene("InfinityStorm4-6");
                break;
            case BTNType.ButtonSound_On:
                btnClick();
                // 버튼음실행
                break;
            case BTNType.ButtonSound_Off:
                btnClick();
                // 버튼음중단
                break;
            case BTNType.BGM_On:
                btnClick();
                // BGM실행
                break;
            case BTNType.BGM_Off:
                btnClick();
                // BGM중단
                break;
            case BTNType.BossStage:
                SceneManager.LoadScene("BossStageBlue");
                break;
        }

    }

    void btnClick()     // 버튼이 눌렸을때 실행할 오디오 클립
    {
        audioSource.clip = mainUIsound.btnClick;
        audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
        audioSource.clip = mainUIsound.onPointer;       // 커서 사운드 설정(형준)
        audioSource.Play(); // 커서 사운드 재생(형준)
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
