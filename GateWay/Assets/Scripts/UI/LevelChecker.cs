using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChecker : MonoBehaviour
{
    public GameObject[] levels;

    string sceneName;

    int level;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Stage1_LevelScene")
        {
            level = PlayerPrefs.GetInt("Fire", 0);
            for (int i = 0; i < level; i++) 
            {
                levels[i].SetActive(true);
            }
        }
        else if (sceneName == "Stage2_LevelScene")
        {
            level = PlayerPrefs.GetInt("Water", 0);
            for (int i = 0; i < level; i++)
            {
                levels[i].SetActive(true);
            }
        }
        else if (sceneName == "Stage3_LevelScene")
        {
            level = PlayerPrefs.GetInt("Mech", 0);
            for (int i = 0; i < level; i++)
            {
                levels[i].SetActive(true);
            }
        }
        else if (sceneName == "Stage4_LevelScene")
        {
            level = PlayerPrefs.GetInt("Wind", 0);
            for (int i = 0; i < level; i++)
            {
                levels[i].SetActive(true);
            }
        }
        PlayerPrefs.Save();



    }

}
