using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ArrowController : MonoBehaviour
{
    public GameObject player;
    public PlayerState playerstate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GameObject");
       //playerstate = GameObject.Find("player").GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 충돌 처리를하자 , 플레이어와 충돌시 삭제
            Destroy(this.gameObject);
            //playerstate.PlayerDead();
        }
    }
}
