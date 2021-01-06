using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==================================================
// 벡터 테스트
// 벡터 값 더하기
//==================================================

public class VectorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 playerPos = new Vector2(3.0f, 4.0f);
        playerPos.x += 9.0f;
        playerPos.y += 5.0f;
        Debug.Log(playerPos);

        transform.position = playerPos;

        Vector2 startPos = new Vector2(2.0f, 1.0f);
        Vector2 endPos = new Vector2(8.0f, 5.0f);
        Vector2 dir = endPos - startPos;

        Debug.Log(dir);

        float length = dir.magnitude;
        Debug.Log(length);

        dir = startPos * 5;
        Debug.Log(dir);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
