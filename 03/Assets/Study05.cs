using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study05 : MonoBehaviour
{
    // 기획을 할 때도 기본적으로 추상적인 대상을 만들고 세부적인 것들을 정의함
    // 속성에 해당하는 변수들을 정의
    // 행동에 해당하는 메소드들을 정의

    // 전투 기획
    // 공격하기, 스킬 사용하기, 피격당하기 등으로 추상적인 항목 대상화
    // 그리고 각각의 추상적 대상을 세부 설계

    // 공격하기
    // - 공격 모션
    // - 타격 판정
    // - 데미지 산출

    // 피격 판정
    // - 공격자의 명중률 계산
    // - 피격자의 회피율, Block율 계산
    // - 크리티컬 판정 계산
    // - 피격 이펙트 출력
    // - 피격 모션 출력
    // - 피격 사운드 출력

    // 데미지 산출
    // - 공격자 공격력 계산
    // ㄴ 스탯, 장비, 버프 값 등등 계산
    // - 방어자 방어력 계산
    // ㄴ 스탯, 장비, 버프 값 등등 계산
    // - 공격력과 방어력의 감산 처리
    // ㄴ 얼마만큼 HP를 감소시킬 것인가 계산
    // 데미지 출력하기

    //======================================

    // 플레이어용 기본 데이터
    int playerAtk = 100;
    int playerSwordAtk = 50;
    int playerDmg; // 기본 공격력 (스탯 공격력 + 칼 공격력)

    // 몹 데이터
    int monsterDef = 30;
    int monsterHP = 1000;

    int atkResult;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("몬스터 HP: " + monsterHP);
        Debug.Log("첫 번째 공격!");
        Attack();

        Debug.Log("몬스터 HP: " + monsterHP);
        Debug.Log("두 번째 공격!");
        Attack();

        Debug.Log("몬스터 HP: " + monsterHP);
        Debug.Log("세 번째 공격!");
        Attack();

    }

    void Attack()
    {
        playerDmg = playerAtk + playerSwordAtk;
        Debug.Log("플레이어 공격력: " + playerDmg);
        atkResult = playerDmg - monsterDef;
        Debug.Log("몹이 받은 데미지: " + atkResult);
        monsterHP -= atkResult;
        Debug.Log("몬스터 HP: " + monsterHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
