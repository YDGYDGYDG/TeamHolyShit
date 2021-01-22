using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // 카메라가 플레이어를 따라 이동함(도균이형 카메라 컨트롤러 코드 에러 나서 임시로 만듦)

    GameObject player;  // 플레이어 연결할 변수

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");        // 플레이어 오브젝트 연결
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;         // 현재 플레이어 위치 좌표 갱신
        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);                 // 카메라위 위치는 플레이어의 위치 따라감
    }
}
