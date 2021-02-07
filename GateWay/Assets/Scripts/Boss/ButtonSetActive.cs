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
            if (on.red && on.blue && on.grey && on.white)
            {
                text.SetActive(true);
                boss.SetActive(true);
            }
        }

    }
}
