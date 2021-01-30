using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject player;  // 플레이어
    PlayerState playerState;    // 플레이어 스크립트
    Vector2 checkPoint = new Vector2();     // 체크포인트 깃발 포지션

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerState = player.GetComponent<PlayerState>();
        checkPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerState.playerStartPosition = checkPoint;
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
