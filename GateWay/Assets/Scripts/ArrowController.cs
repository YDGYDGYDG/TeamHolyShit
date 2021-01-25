using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 화살이 떨어진다
// ㄴ 시간이 지남에 따라 아래로 이동시킨다.
// ㄴ 화면 아래로 사라지면 화살은 소멸한다
//     ㄴ 왜? 효율적으로 메모리 관리하기 위해

// 충돌을 체크하는 방법
// Collider를 이용하여 물리적인 계산을 하여 판정하는 방법
// ㄴ Unity가 실시간으로 계속 계산을 해주는 방식
// 오브젝트간의 거리를 계산하여 판정하는 방식

// 게임을 만들다 보면
// 화살처럼 하나만 단독으로 존재하는 것이 아니라 필요에 따라 여러개를 생성해야 하는 경우가 있음
// 없는 오브젝트를 생성해줘야 하는 경우도 있음
// 이럴 경우에 객체의 생성, 소멸, 유지를 담당하는 기능을 하는 객체를 제네레이터라고 함

public class ArrowController : MonoBehaviour
{
    GameObject playerObj;   // 플레이어 오브젝트를 참조하기 위한 변수

    Vector2 arrowPosition;  // 화살의 좌표 값을 참조하기 위한 변수
    Vector2 playerPosition; // 플레이어의 좌표와 값을 참조하기 위한 변수
    Vector2 dir;            // 화살과 플레이어 간의 거리를참조하기 위한 변수

    float arrowRound = 0.5f;   // 화살의 충돌반경 값
    float playerRound = 1.0f;  // 플레이어 충돌반경 값


    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 이동시킨다
        transform.Translate(-0.1f, 0, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.x < -6.0f)
        {
            Destroy(this.gameObject);
            // Destroy(오브젝트)
            // 해당 오브젝트를 삭제(소멸)한다
        }

        arrowPosition = transform.position;
        playerPosition = playerObj.transform.position;
        dir = arrowPosition - playerPosition;
        float distance = dir.magnitude;  // dir 벡터의 길이값을 계산하여 대입

        if (distance < arrowRound + playerRound)
        {
            // 충돌 처리를하자 , 플레이어 HP를 감소시키고, 파괴되면 됨
            Destroy(this.gameObject);

        }
    }
}
