using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlade : MonoBehaviour
{
    public Transform startPos;  // 시작 위치
    public Transform endPos;    // 끝나는 위치
    public Transform desPos;
    public float speed;
    PlayerController  playerDeath;     // 죽는거 하자

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
        playerDeath = GameObject.Find("player").GetComponent<PlayerController>();
    }
    public void Moveoff()
    {
        this.transform.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDeath.PlayerDead();
        }
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
    }

}
