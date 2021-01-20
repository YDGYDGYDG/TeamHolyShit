using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    float timeStack = 0;    // 타이머
    float span = 1.0f;  // 생성 간격

    GameObject playerController;

    Vector2 playerPosition; // 플레이어 포지션

    public GameObject firePrefab;

    GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("player");
    }
    
    // Update is called once per frame
    void Update()
    {
        timeStack += Time.deltaTime; // 타이머

        playerPosition = playerController.transform.position; // 플레이어 좌표값 불러오기

        if (timeStack > span)
        {
            timeStack = 0;
            // 불덩이 프리팹 생성
            fire = Instantiate(firePrefab) as GameObject;
            // 불덩이가 캐릭터를 따라다니네
            fire.transform.position = new Vector3(Random.Range(playerPosition.x-3,playerPosition.x+3), 5.7f, 0);

        }
    }
}
