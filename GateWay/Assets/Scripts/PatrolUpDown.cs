using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolUpDown : MonoBehaviour
{
    public float speed;
    public bool isUp = true;

    void Update()
    {
        if (isUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        // 엠티오브젝트에 충돌되면 방향이 바뀌는 스크립트
        // 엠티오브젝트 태그를 endpoint로 만들고 패트롤 양끝에 배치
        // 충돌되면 위로, 충돌되면 아래로 이동하게 만듦
    {
        if(collision.tag == "endpoint")
        {
            if(isUp)
            {
                isUp = false;
            }
            else
            {
                isUp = true;
            }
        }      
    }
}
