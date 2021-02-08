using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChecker : MonoBehaviour
{
    public GameObject bossPlanet;

    int fireLv = 0;
    int waterLv = 0;
    int windLv = 0;
    int mechLv = 0;

    void Start()
    {
        fireLv = PlayerPrefs.GetInt("Fire", 0);
        waterLv = PlayerPrefs.GetInt("Water", 0);
        windLv = PlayerPrefs.GetInt("Wind", 0);
        mechLv = PlayerPrefs.GetInt("Mech", 0);
        PlayerPrefs.Save();

        if (fireLv == 4 && waterLv == 4 && windLv == 5 && mechLv == 5)
        {
            bossPlanet.SetActive(true);
        }
    }
}
