using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Disappear : MonoBehaviour
{
    HookShotScript hook_script;

    [SerializeField] Image black;

    void Start()
    {
      
        hook_script = GetComponent<HookShotScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "diswall")
        {
            Debug.Log("제발실행해젭ㄷㄱㄹ ㅓㅐㅇ");
            Destroy(collision.gameObject, 1);
            hook_script.HookOFF();
        }

        if(collision.gameObject.name == "ClearBox")
        {
            Debug.Log("Clear");
            if(black != null)
            {
                black.gameObject.SetActive(true);

                float sec = 3f;
                float cur_sec = 0f;
                while(cur_sec < sec)
                {
                    cur_sec += Time.deltaTime;
                }

                // 씬이동 여기 씬 이름 sjgg
                SceneManager.LoadScene("Game");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "diswall")
        {
            Debug.Log("되라");
            Destroy(collision.gameObject, 1);
        }
    }
}