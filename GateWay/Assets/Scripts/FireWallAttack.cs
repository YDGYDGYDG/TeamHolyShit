using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallAttack : MonoBehaviour
{
    
    PlayerController playerController;
    BoxCollider2D fireCollider;
    FireWallController fireWallController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
        fireCollider = GameObject.Find("FireWallLine").GetComponent<BoxCollider2D>();
        fireWallController = GameObject.Find("FireWall").GetComponent<FireWallController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        // 충돌 사이즈 ray 위치만큼 변경
        fireCollider.size = new Vector2(1, fireWallController.hitPoint);
        // 충돌 위치 ray 위치만큼 변경
        fireCollider.offset = new Vector2(0, (fireWallController.hitPoint/2));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.PlayerDead();
        }
    }
}
