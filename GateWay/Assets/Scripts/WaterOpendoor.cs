using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterOpendoor : MonoBehaviour
{
    StarController starCon;

    void Start()
    {
        starCon = GameObject.Find("Star").GetComponent<StarController>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (starCon.star == true)
        {
            if (col.gameObject.tag == "Player")        // 너 플레이어랑 충돌했니??
            {
                if (SceneManager.GetActiveScene().name == "WaterStage1")      // 현재 스테이지 이름 확인하고
                {
                    SceneManager.LoadScene("WaterStage2");                   // 맞으면 다음씬으로 넘어가
                }

                else if (SceneManager.GetActiveScene().name == "WaterStage2")
                {
                    SceneManager.LoadScene("WaterStage3");
                }

                else if (SceneManager.GetActiveScene().name == "WaterStage3")
                {
                    SceneManager.LoadScene("WaterStage4");
                }

                else if (SceneManager.GetActiveScene().name == "WaterStage4")
                {
                    SceneManager.LoadScene("WaterStage5");
                }

                else if (SceneManager.GetActiveScene().name == "WaterStage5")
                {
                    SceneManager.LoadScene("WaterStage6");
                }

            }
        }

    }



}
