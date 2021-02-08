using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIbgm : MonoBehaviour
{

    public static MainUIbgm Instance;

    AudioSource audioSource;
    public AudioClip[] audioClips;

    string sceneName;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sceneName = SceneManager.GetActiveScene().name;
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            // 로비
            case "TitleScene":
                ChangeBGM(0);
                break;
            case "MainScene":
                ChangeBGM(0);
                break;
            case "OptionScene":
                ChangeBGM(0);
                break;
            case "CreditScene":
                ChangeBGM(0);
                break;
            case "StageSelectScene":
                ChangeBGM(0);
                break;

            // 튜토
            case "TutorialStage1":
                sceneName = SceneManager.GetActiveScene().name;
                audioSource.clip = null;
                break;
            case "TutorialStage2":
                sceneName = SceneManager.GetActiveScene().name;
                audioSource.clip = null;
                break;
            case "TutorialStage3":
                sceneName = SceneManager.GetActiveScene().name;
                audioSource.clip = null;
                break;
            // 불
            case "LavaStage1":
                ChangeBGM(1);
                break;
            case "LavaStage2":
                ChangeBGM(1);
                break;
            case "LavaStage3":
                ChangeBGM(1);
                break;
            case "LavaStage4":
                ChangeBGM(1);
                break;
            // 물
            case "WaterPlanet1":
                ChangeBGM(3);
                break;
            case "WaterPlanet2":
                ChangeBGM(3);
                break;
            case "WaterPlanet3":
                ChangeBGM(3);
                break;
            case "WaterPlanet4":
                ChangeBGM(3);
                break;
            case "WaterPlanet5":
                ChangeBGM(3);
                break;
            // 바람
            case "InfinityStorm4-1":
                ChangeBGM(4);
                break;
            case "InfinityStorm4-2":
                ChangeBGM(4);
                break;
            case "InfinityStorm4-3":
                ChangeBGM(4);
                break;
            case "InfinityStorm4-4":
                ChangeBGM(4);
                break;
            case "InfinityStorm4-5":
                ChangeBGM(2);
                break;
            // 기계
            case "MachineryStage1":
                ChangeBGM(5);
                break;
            case "MachineryStage2":
                ChangeBGM(5);
                break;
            case "MachineryStage3":
                ChangeBGM(5);
                break;
            case "MachineryStage4":
                ChangeBGM(6);
                break;
            case "MachineryStage5":
                ChangeBGM(6);
                break;
            // 보스
            case "BossStage":
                ChangeBGM(2);
                break;
        }

        PlayerPrefs.DeleteAll();

    }

    void ChangeBGM(int index)
    {
        if(SceneManager.GetActiveScene().name != sceneName)
        {
            sceneName = SceneManager.GetActiveScene().name;
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }
}
