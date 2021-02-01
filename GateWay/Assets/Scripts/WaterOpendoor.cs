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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (starCon.star == true)
        {
            if (col.gameObject.tag == "Player")        // 너 플레이어랑 충돌했니??
            {
                if (SceneManager.GetActiveScene().name == "WaterPlanet1")      // 현재 스테이지 이름 확인하고
                {
                    SceneManager.LoadScene("WaterPlanet2");                   // 맞으면 다음씬으로 넘어가
                }

                else if (SceneManager.GetActiveScene().name == "WaterPlanet2")
                {
                    SceneManager.LoadScene("WaterPlanet3");
                }

                else if (SceneManager.GetActiveScene().name == "WaterPlanet3")
                {
                    SceneManager.LoadScene("WaterPlanet4");
                }

                else if (SceneManager.GetActiveScene().name == "WaterPlanet4")
                {
                    SceneManager.LoadScene("WaterPlanet5");
                }

            }
        }
    }
    


}
