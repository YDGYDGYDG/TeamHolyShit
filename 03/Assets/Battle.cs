using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 44번 수업 자료

public class Battle : MonoBehaviour
{
    // 마우스 왼쪽 클릭으로 랜덤 오브젝트에게 공격을 가하기

    // 몬스터 오브젝트 저장고
    List<GameObject> monsterList = new List<GameObject>();

    //
    Transform monsterTransform;

    // Start is called before the first frame update
    void Start()
    {
        monsterTransform = transform.Find("MonsterMng");

        foreach (Transform monster in monsterTransform)
        {
            // 관리할 수 있도록 리스트에 추가
            monsterList.Add(monster.gameObject);
            // 그 다음 활성 디폴트 상태는 off로
            monster.GetComponent<Renderer>().material.color = Color.green;
            //monster.gameObject.GetComponent<Renderer>().material.color = Color.green; // 위와 같은 결과
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int target = Random.Range(0, monsterList.Count);
            monsterList[target].GetComponent<Monster>().Damage();
        }
    }
}
