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
