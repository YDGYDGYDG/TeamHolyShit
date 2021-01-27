using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "TutorialStage1")      // 현재 스테이지 이름 확인하고
            {
                SceneManager.LoadScene("TutorialStage2");                   // 맞으면 다음씬으로 넘어가
            }

            else if (SceneManager.GetActiveScene().name == "TutorialStage2")
            {
                SceneManager.LoadScene("TutorialStage3");
            }

            else if (SceneManager.GetActiveScene().name == "TutorialStage3")
            {
                SceneManager.LoadScene("MainScene");
            }        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
