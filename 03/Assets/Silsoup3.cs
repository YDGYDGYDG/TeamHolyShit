using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silsoup3 : MonoBehaviour
{
    // 실습
    // 전투 시뮬레이터 
    // 클릭시마다 전투 진행 : 클릭 함수에 전투 진행 함수 삽입
    // 매 턴 플레이어와 몬스터 공격 주고받기 : 전투 진행 함수
    // 매 턴 선공이 누구인지는 랜덤 : 랜덤 시드, 플레이어 공격 함수, 몹 공격 함수
    // 둘 중 하나 사망 시 전투 종료 : 전투 종료 플래그, 체력 판정
    // 공격: 평타, 스킬 : 평타 함수, 스킬 함수 중 랜덤 출력
    // 피격: 피격, 회피 : 피격 함수, 회피 함수 중 랜덤 출력
    // 몬스터 사망 시 골드, 경험치 : 몹 사망 판정, 보상 함수
    // 플레이어 사망 시 게임 오버 메시지 : 플레이어 사망 판정, 게임 오버 메시지 함수
    // 플레이어 HP 30% 이하면 힐링 발생 : 플레이어 체력 체크, 힐 함수
    // 최소 1회 최대 HP의 75%가 회복된다. : 힐 플래그, 힐 함수

    // 위 내용을 구현하기 위한 계획
    /*
        0. 플레이어와 몬스터 스탯
            플레이어: HP, 공격력, 방어력, 크리율, 회피율, 보유 골드, 보유 경험치
            몹: HP, 공격력, 방어력, 크리율, 회피율, 보상 골드, 보상 경험치
        1. 오브젝트 클릭마다 한 턴 진행
            오브젝트 클릭하는 기능
        2. 플레이어와 몬스터의 공격 수행
            유닛들의 공격 처리
        3. 선공 랜덤
            선공 판단
            선공이 플레이어 - 플레이어 공격, 몹 공격
            선공이 몬스터 - 몹 공격, 플레이어 공격
        4. 공격: 평타, 크리, 회피 발생
            평타
        5. 플레이어 체력 30% 미만일 시 회복 발동
        6. 플레이어나 몬스터가 사망하면 전투 종료
    */

    // 유닛 클래스
    public class Unit
    {
        // 능력치
        public string name;
        public int atk;
        public int def;
        public int hp;
        public int max_hp;
        public int agi;
        public int dex;
        public int gold;
        public int exp;
        // 함수용 변수
        private int randomMin = 0;
        private int randomMax = 100;
        private int criticalMin = 12;
        private int criticalMax = 15;
        private int randomCount;
        // 생성자
        public Unit(string _name, int _atk, int _def, int _hp, int _max_hp, int _agi, int _dex, int _gold, int _exp)
        {
            name = _name;
            atk = _atk;
            def = _def;
            hp = _hp;
            max_hp = _max_hp;
            agi = _agi;
            dex = _dex;
            gold = _gold;
            exp = _exp;
        }
        // 공격 명령
        public void Attack(Unit unit)
        {
            randomCount = Random.Range(randomMin, randomMax);
            if (randomCount < dex)
                SkillToUnit(unit);
            else
                AttakToUnit(unit);
        }

        // 평타 공격
        public void AttakToUnit(Unit unit)
        {
            Debug.Log(">> " + name + "의 공격!");
            randomCount = Random.Range(randomMin, randomMax);
            if (randomCount > unit.agi)
            {
                Debug.Log(">>>> " + unit.name + "는 공격을 받았다!");
                unit.hp -= (atk - unit.def);
            }
            else
                Debug.Log(">>>> 그러나 " + unit.name + "는 피했다!");
            unit.UpdateState();
        }
        // 크리 공격
        public void SkillToUnit(Unit unit)
        {
            randomCount = Random.Range(randomMin, randomMax);
            Debug.Log(">> " + name + "의 강력한 공격!");
            if (randomCount > unit.agi)
            {
                // 크리 비율 판정
                randomCount = Random.Range(criticalMin, criticalMax);
                unit.hp -= randomCount * (atk - unit.def) / 10;
                Debug.Log(">>>> " + unit.name + "는 " + 1.0f*randomCount/10 + "배의 공격을 받았다!");
            }
            else
                Debug.Log(">>>> 그러나 " + unit.name + "는 피했다!");
            unit.UpdateState();
        }
        // 사망
        public void Death()
        {
            Debug.Log(">> " + name + "가 사망했다! \n전투가 끝났다.");
        }
        // 현상황 정리
        public void UpdateState()
        {
            if (hp > max_hp)
                hp = max_hp;
            if (hp < 0)
                hp = 0;
            //Debug.Log("------------------------");
            Debug.Log("-- " + name + "의 현재 체력: " + hp);
        }
        // 보상
        public void Award(Unit unit)
        {
            Debug.Log("++ " + name + "는 " + unit.name + "를 이기고 " + unit.gold + "의 골드와 " + unit.exp + "의 경험치를 얻었다!");
        }
    }

    // 유닛 생성: 이름, 공격력, 방어력, HP, 최대HP, 회피, 크리율, 돈, 경험치
    public Unit player = new Unit("플레이어", 100, 30, 1000, 1000, 25, 30, 100, 100);
    public Unit monster = new Unit("몬스터", 150, 30, 1000, 1000, 33, 30, 500, 500);

    // 랜덤 시드
    int RandMIN = 0;
    int RandMAX = 100; // 
    int firstRandom = 0; // 선제 행동 카운트

    // 일회용 플래그들
    bool battleFlag = true;
    bool healFlag = true;

    // 카운터 (그냥 넣어봄 ㅎ)
    int battleCount = 0;

    // 클릭시 발생
    private void OnMouseDown()
    {
        // 전투 중 판단
        if (battleFlag)
        {
            // 턴 시작
            battleCount++;
            Debug.Log(battleCount + "번째 턴 전투 개시!");

            // 전투
            firstRandom = Random.Range(RandMIN, RandMAX);
            if (firstRandom < 50)
            {
                // 플레이어 선공
                player.Attack(monster);
                // 앞선 공격으로 몬스터가 죽었나?
                if (monster.hp > 0)
                    monster.Attack(player);
            }
            else
            {
                // 플레이어 후공
                monster.Attack(player);
                // 앞선 공격으로 플레이어가 죽었나?
                if (player.hp > 0)
                    player.Attack(monster);
            }
            // 전투 이후 판단
            // 플레이어 HP 30% 미만이면 1회 힐
            if (healFlag && player.hp < (player.max_hp / 3))
            {
                player.hp += (player.max_hp / 4 * 3);
                healFlag = false;
                Debug.Log("++ 기진맥진한 플레이어에게 신의 가호가 내려졌다!");
                player.UpdateState();
            }
            // 이후 사망 판단
            if (player.hp <= 0)
            {
                player.Death();
                monster.Award(player);
                battleFlag = false;
            }
            if (monster.hp <= 0)
            {
                monster.Death();
                player.Award(monster);
                battleFlag = false;
            }
        }
        else
        {
            Debug.Log("전투가 끝났다.");
        }
        Debug.Log("========================");
    }

}
