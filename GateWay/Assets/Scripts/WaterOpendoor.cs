using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterOpendoor : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
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



    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }




}
