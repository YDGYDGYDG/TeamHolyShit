using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrap : MonoBehaviour
{

    float span = 2.0f;      // 재생성 시간
    float delta = 0;        // 초기화 시간

    Rigidbody2D jump;
    public float jumpForce = 1000.0f;   // 점프 높이

    SpriteRenderer flip;                // 이미지 위치 전환

    CircleCollider2D circleCollider;    // 충돌 트리거

    Vector2 position = new Vector2();   // 투명도 조절 기준 위치
    
    

    // Start is called before the first frame update
    void Awake()
    {
        
        flip = GetComponent<SpriteRenderer>();      // 렌더러 연결

        position = transform.position;              // 기준은 오브젝트가 배치된 위치

        this.jump = GetComponent<Rigidbody2D>();    // 물리작용 컴포넌트 연결

        circleCollider = GetComponent<CircleCollider2D>();  // 원형 충돌체크 트리거 연결

        InvokeRepeating("jumping", 0, 2.0f);        // 2초마다 반복해서 점핑해

    }

    void jumping()
    {
        this.jump.AddForce(transform.up * this.jumpForce);  // 가하는 힘 = jumpForce
    }

    // Update is called once per frame
    void Update()
    {
      if(jump.velocity.y < 0)   // 하강중일때
        {
            flip.flipY = true;    // 낙하 애니메이션
            
        }
      
      else if(jump.velocity.y > 0)  // 상승중일때
        {
            flip.flipY = false;   // 상승 애니메이션
            
            
        }


     
     if(this.transform.position.y < this.position.y)    // 시작위치에서는?
       {
            
            // 투명하게 바꿔라
            flip.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
        }

        else if (this.transform.position.y > this.position.y)   // 상승중일때
        {
            // 다시 표시해
            flip.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }

    }

    

}
