using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study07 : MonoBehaviour
{
    // 플레이어용 기본 데이터
    float playerAtk = 100;
    float playerSwordAtk = 50;
    float playerDmg; // 기본 공격력 (스탯 공격력 + 칼 공격력)

    // 몹 데이터
    float monsterDef = 30;
    float monsterHP = 1000;
    float monsterMaxHP = 1000;

    int atkResult;
    // 그냥 공격에 크리티컬을 추가해보자
    //void Attack()
    //{
    //    playerDmg = playerAtk + playerSwordAtk;
    //    Debug.Log("플레이어 공격력: " + playerDmg);
    //    atkResult = CalcDamage(playerDmg , monsterDef);
    //    Debug.Log("몹이 받은 데미지: " + atkResult);
    //    monsterHP -= atkResult;
    //    Debug.Log("몬스터 HP: " + monsterHP);
    //}

    // 데미지 계산해주는 함수
    // 공격력과 방어력을 받아서 기본 데미지 계산
    // 크리배율을 받아서 랜덤 적용
    // 1.0배 ~ 1,5배
    // 최종 데미지를 산출해 Result로 반환
    int CalcDamage(int atk, int def)
    {
        float damage = atk - def;
        float criRate = Random.Range(1.0f, 1.5f);

        damage = damage * criRate;
        int result = (int)damage;
        return result;
    }

    // 실습
    // 상대 체력 비례 데미지를 주는 스킬
    // 3번의 공격을 가한다.
    // 적의 HP가 100%면 추뎀 100%
    // 매 공격마다 방어력도 20% 감소시킨다.
    void SuperTripleAttack(int slash, float atk, float def, float hp, float maxHp)
    {
        // 공격
        // 적 HP 판단
        // 공격력 계산
        // 적 방어력 감소
        float damage = atk * (1 + hp/ maxHp) - def;
        monsterHP -= damage;
        
        Debug.Log(slash + "번째 공격 먹어라!");
        Debug.Log("현재 공격력: " + atk);
        Debug.Log("추가 데미지 배율: " + (1 + hp / maxHp));
        Debug.Log("현재 몬스터 방어력: " + (int)monsterDef);
        Debug.Log("결과 데미지: " + (int)damage);
        Debug.Log("남은 몬스터 체력: "+ (int)monsterHP);

        monsterDef *= 0.8f;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerDmg = playerAtk + playerSwordAtk;
        for (int i = 1; i < 4; i++)
            SuperTripleAttack(i, playerDmg, monsterDef, monsterHP, monsterMaxHP);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
