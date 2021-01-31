using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public Transform startPos;  // 시작 위치
    public Transform endPos;    // 끝나는 위치
    public Transform desPos;
    public float speed;

    GameObject playerTrans;
    PlayerMoveController playerMove;
    Vector3 playerPos;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
        playerMove = GameObject.Find("player").GetComponent<PlayerMoveController>();
    }
    // 충돌 시 캐릭터가 벽을 따라다니게 하기 (보류)

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // if (collision.transform.CompareTag("Player"))
    //     // {
    //     //     collision.transform.SetParent(transform);
    //     // }
    //     if (collision.contacts[0].normal.y == -1)
    //     {
    //         if (collision.gameObject.tag == "Player")
    //         {
    //             playerTrans = collision.gameObject;
    //             playerPos = playerTrans.transform.position;
    //             distance = transform.position - playerPos;
    //         }
    //     }
    // }
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     // if (collision.transform.CompareTag("Player"))
    //     // {
    //     //     collision.transform.SetParent(null);
    //     // }
    //     playerTrans = null;
    // }
    public void Moveoff()
    {
        this.transform.SetParent(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos)
            {
                desPos = startPos;
            }
            else
            {
                desPos = endPos;
            }

        }
        // 캐릭터가 벽을 따라다니게 하기 (보류)
        // if (playerTrans != null)
        // {
        //     if (playerMove.jump == false && playerMove.LBTrigger == false && playerMove.RBTrigger == false)
        //     {
        //         playerTrans.transform.position = transform.position - distance;
        //     }
        // }
    }
}