﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        // player에 PlayerController 참조
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 캐릭터랑 충돌 시
        if (other.gameObject.tag == "Player")
        {
            playerController.PlayerDead();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 아래로 떨어짐
        transform.Translate(0, -0.1f, 0);

        // 화면밖으로 나가면 소멸
        if (transform.position.y < -50.0f)
        {
            Destroy(this.gameObject);
        }
    }
}