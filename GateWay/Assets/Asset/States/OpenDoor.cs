using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
    {
        
       if (col.gameObject.tag == "Player")  // 너 플레이어랑 충돌했니??
       {
            // =========================== 김형준(용암) =====================================
            if (SceneManager.GetActiveScene().name == "LavaStage1")    // 현재 스테이지 이름 확인하고
            {
                SceneManager.LoadScene("LavaStage2");    // 맞으면 다음씬으로 넘어가(2 스테이지 이동)
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage2")
            {
                SceneManager.LoadScene("LavaStage3");   // 3 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage3")
            {
                SceneManager.LoadScene("LavaStage4");   // 4 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage4")
            {

                SceneManager.LoadScene("ClearScene"); // 클리어 화면으로 이동
            }
            //=============================================================================




            // =========================== 김나연(물) =====================================
            else if (SceneManager.GetActiveScene().name == "WaterPlanet1")
            {
                SceneManager.LoadScene("WaterPlanet2");  // 2 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "WaterPlanet2")
            {
                SceneManager.LoadScene("WaterPlanet3");  // 3 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "WaterPlanet3")
            {
                SceneManager.LoadScene("WaterPlanet4");  // 4 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "WaterPlanet4")
            {
                SceneManager.LoadScene("ClearScene"); // 클리어 화면으로 이동
            }
            //=============================================================================




            // =========================== 김휘원(튜토리얼) =====================================
            else if (SceneManager.GetActiveScene().name == "TutorialStage1")
            {
                SceneManager.LoadScene("TutorialStage2");   // 2 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "TutorialStage2")
            {
                SceneManager.LoadScene("TutorialStage3");   // 3 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "TutorialStage3")
            {
                SceneManager.LoadScene("ClearScene"); // 클리어 화면으로 이동
            }
            //=============================================================================




            // =========================== 유건희(바람) =====================================
            else if (SceneManager.GetActiveScene().name == "InfinityStorm4-1")
            {
                SceneManager.LoadScene("InfinityStorm4-2"); // 2 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "InfinityStorm4-2")
            {
                SceneManager.LoadScene("InfinityStorm4-3"); // 3 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "InfinityStorm4-3")
            {
                SceneManager.LoadScene("InfinityStorm4-4"); // 4 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "InfinityStorm4-4")
            {
                SceneManager.LoadScene("InfinityStorm4-5"); // 5 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "InfinityStorm4-5")
            {
                SceneManager.LoadScene("ClearScene"); // 클리어 화면으로 이동
            }
            //=============================================================================




            // =========================== 윤도균(기계) =====================================
            else if (SceneManager.GetActiveScene().name == "MachineryStage1")
            {
                SceneManager.LoadScene("MachineryStage2"); // 2 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "MachineryStage2")
            {
                SceneManager.LoadScene("MachineryStage3"); // 3 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "MachineryStage3")
            {
                SceneManager.LoadScene("MachineryStage4"); // 4 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "MachineryStage4")
            {
                SceneManager.LoadScene("MachineryStage5"); // 5 스테이지 이동
            }

            else if (SceneManager.GetActiveScene().name == "MachineryStage5")
            {
                SceneManager.LoadScene("ClearScene"); // 클리어 화면으로 이동
            }
            //=============================================================================
        }

        // 씬 나가기 전에 플레이어 위치 저장해 둔 정보 삭제
        PlayerPrefs.DeleteKey("SavedPlayerX");
        PlayerPrefs.DeleteKey("SavedPlayerY");
    }

}
