using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    float jumpForce = 1000.0f;   // 점프에 전달할 힘 값
    float walkForce = 10.0f;


    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && rigidBody.velocity.y == 0 )
        {
            rigidBody.AddForce(transform.up * jumpForce);
        }


        // 왼쪽으로 이동
        if (Input.GetKey(KeyCode.A) || Input.acceleration.x < -0.2f)
        {
            rigidBody.AddForce(transform.right * -1 * walkForce);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 오른쪽으로 이동
        if (Input.GetKey(KeyCode.D) || Input.acceleration.x > 0.2f)
        {
            rigidBody.AddForce(transform.right * 1 * walkForce);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
