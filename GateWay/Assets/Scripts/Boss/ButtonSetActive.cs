using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetActive : MonoBehaviour
{

    public GameObject text;
    public GameObject boss;
    BossButtonController on;
    // Start is called before the first frame update
    void Start()
    {
        on = GameObject.Find("BossButtonController").GetComponent<BossButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StageSelectScene")
        {
            if (on.red == 1 && on.blue == 1 && on.grey == 1 && on.white == 1)
            {
                text.SetActive(true);
                boss.SetActive(true);
            }
        }

    }
}
