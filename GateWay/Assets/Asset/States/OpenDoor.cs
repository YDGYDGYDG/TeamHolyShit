using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
    {
        
       if (col.gameObject.tag == "Player")        // 너 플레이어랑 충돌했니??
       {
            if (SceneManager.GetActiveScene().name == "LavaStage1")      // 현재 스테이지 이름 확인하고
            {
                SceneManager.LoadScene("LavaStage2");                   // 맞으면 다음씬으로 넘어가
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage2")
            {
                SceneManager.LoadScene("LavaStage3");
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage3")
            {
                SceneManager.LoadScene("LavaStage4");
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage4")
            {
                SceneManager.LoadScene("LavaStage5");
            }

            else if (SceneManager.GetActiveScene().name == "LavaStage5")
            {
                SceneManager.LoadScene("LavaStage6");
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
