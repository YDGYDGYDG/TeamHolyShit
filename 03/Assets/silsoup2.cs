using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silsoup2 : MonoBehaviour
{
    // 실습과제 3
    // 마우스를 클릭하면 플레이어가 몬스터를 공격하고
    // 마우스를 떼면 몬스터가 플레이어를 공격하도록 구현하기
    // 콘솔로 나오면 됨
    //=================================================================

    // 플레이어용 기본 데이터
    int playerAtk = 200;
    int playerSwordAtk = 50;
    int playerDmg; // 기본 공격력 (스탯 공격력 + 칼 공격력)
    int playerDef = 50;
    int playerHP = 1000;

    // 몹 데이터
    int monsterAtk = 100;
    int monsterDef = 30;
    int monsterHP = 1000;

    // 랜덤 시드
    int CRIMIN = 0;
    int CRIMAX = 2;

    bool flag = true;

    private void OnMouseDown()
    {
        int damage;
        if (monsterHP > 1)
        {
            Debug.Log("당신의 공격!");
            int criRate = Random.Range(CRIMIN, CRIMAX);
            if (criRate > 1)
            {
                Debug.Log(">> 급소에 맞혔다!");
                damage = playerDmg * 2;
            }
            else if (criRate > 0 && criRate < 2)
            {
                Debug.Log(">> 맞혔다!");
                damage = playerDmg;
            }
            else
            {
                Debug.Log(">> 빗나갔다 ㅜ.ㅜ");
                damage = monsterDef;
            }
            Debug.Log(">>>> 데미지: " + damage);
            monsterHP -= (damage - monsterDef);
            if (monsterHP < 0)
            {
                monsterHP = 0;
            }
            Debug.Log("몬스터 체력: " + monsterHP);
        }
        
        else
        {
            Debug.Log("몬스터다!");
            Debug.Log("아니... 그냥 시체인 듯 하다.");
        }

        Debug.Log("===============================");
    }
    private void OnMouseUp()
    {
        int damage;
        if (monsterHP > 1)
        {
            Debug.Log("몬스터의 반격!");
            int criRate = Random.Range(CRIMIN, CRIMAX);
            if (criRate > 1)
            {
                Debug.Log(">> 컥, 급소에 맞았다...");
                damage = monsterAtk * 2;
            }
            else if (criRate > 0 && criRate < 2)
            {
                Debug.Log(">> 맞았다!");
                damage = monsterAtk;
            }
            else
            {
                Debug.Log(">> 나이스! 피했다!");
                damage = playerDef;
            }
            Debug.Log(">>>> 데미지: " + damage);
            playerHP -= (damage - playerDef);
            Debug.Log("나의 체력: " + playerHP);
        }
        else if (!flag)
        {
            Debug.Log("아무 일도 일어나지 않았다.");
        }
        else
        {
            Debug.Log("야호야호! 몬스터를 잡았다!");
            Debug.Log("보상: \'교수님의 칭찬\' 획득");
            flag = false;
        }
        Debug.Log("===============================");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerDmg = playerAtk + playerSwordAtk;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
