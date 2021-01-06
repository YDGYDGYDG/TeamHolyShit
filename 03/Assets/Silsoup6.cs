using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silsoup6 : MonoBehaviour
{
    // 실습
    /*
     * < 전투를 구현 >
     * 
     * 플레이어는 키 입력을 받아 공격함
     * 몬스터는 자동으로 공격함
     * 선공은 랜덤
     * 
     * 플레이어 공격은 QWER 4종류
     * Q 평타
     * W 강타 - 한 번의 전투 당 1회만 사용 가능
     * E 힐 - 3회만 사용 가능
     * R 3턴 간 공격력 1.5배로 증가 - 5턴 쿨타임
     * # 당연히 크리티컬, 회피가 있다
     * 
     * 몬스터의 능력치
     * 몬스터를 처치하면 다음 몬스터는 모든 능력치 +10%
     * 
     * 캐릭터의 HP가 낮아질 수록 색이 변한다.
     * 
     * 플레이어 사망 시
     * 총 몇 마리의 몬스터를 잡았는지 출력
     * 게임 종료
     * 
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
        protected int randomMin = 0;
        protected int randomMax = 100;
        protected int critical = 15; // 크리배율: 1.5배
        protected int randomCount;

        // 생성자
        public Unit() { }
        
        // 사망
        public virtual void Death()
        {
            Debug.Log(">> " + name + "가 사망했다!");
        }

        // 현상황 정리
        public virtual void UpdateState()
        {
            if (hp > max_hp)
                hp = max_hp;
            if (hp < 0)
                hp = 0;
            //Debug.Log("------------------------");
            Debug.Log("-- " + name + "의 현재 체력: " + hp);
        }

        public virtual void Initialize() { }

    }

    // 플레이어 클래스
    public class Player : Unit
    {
        // 생명
        public int playerLife = 1;
        // 원래 공격력
        int defaultAtk;
        // 몹 잡은 수
        int carma = 0;
        // 힐 횟수
        public int healPower = 3;
        // 강공격 횟수
        public int skillPower = 1;
        // 버프
        public int cooltime = 0;
        public int bufftime = 0;

        public Player(string _name, int _atk, int _def, int _hp, int _max_hp, int _agi, int _dex, int _gold, int _exp)
        {
            name = _name;
            atk = _atk;
            defaultAtk = _atk;
            def = _def;
            hp = _hp;
            max_hp = _max_hp;
            agi = _agi;
            dex = _dex;
            gold = _gold;
            exp = _exp;
        }

        public override void Initialize()
        {
            // 쿨타임, 버프, 강공격기회 초기화
            skillPower = 1;
            bufftime = 0;
            cooltime = 0;
            RageBuffOff();
        }

        // 평타 공격
        public void AttakToUnit(Unit unit)
        {
            Debug.Log(">> " + name + "의 공격!");
            randomCount = Random.Range(randomMin, randomMax);
            if (randomCount > unit.agi)
            {
                randomCount = Random.Range(randomMin, randomMax);
                if (randomCount < unit.dex)
                {
                    Debug.Log(">> 치명타 발생!");
                    Debug.Log(">>>> " + unit.name + "는 급소에 공격을 받았다!");
                    unit.hp -= (int)(1.5f * atk) - unit.def;
                }
                else
                {
                    Debug.Log(">>>> " + unit.name + "는 공격을 받았다.");
                    unit.hp -= (atk - unit.def);
                }
            }
            else
                Debug.Log(">>>> 그러나 " + unit.name + "는 피했다!");
            unit.UpdateState();
        }

        // 강타 공격
        public void SkillToUnit(Unit unit)
        {
            if(skillPower > 0)
            {
                randomCount = Random.Range(randomMin, randomMax);
                Debug.Log(">> " + name + "의 강타 공격!");
                if (randomCount > unit.agi)
                {
                    Debug.Log(">>>> " + unit.name + "는 공격을 받았다!");
                    unit.hp -= atk * 3;
                }
                else
                    Debug.Log(">>>> 그러나 " + unit.name + "는 피했다!");

                skillPower--;
                Debug.Log("-- 이제 이 몬스터에게는 강타를 사용할 수 없다.");
                unit.UpdateState();
            }
            else
                Debug.Log(">> 플레이어는 이미 이번 전투에서 강타를 사용했다!");
        }

        public void Healing()
        {
            if(healPower > 0)
            {
                Debug.Log(">> 플레이어는 포션을 마셨다!");
                Debug.Log("-- 최대 체력의 1/3이 회복되었다. ");
                hp += max_hp / 3;
                healPower--;
                Debug.Log("-- 남은 포션: " + healPower + "개");
                UpdateState();
            }
            else
            {
                Debug.Log(">> 플레이어는 포션을 찾았지만 주머니가 비어있다...");
            }
        }
        public void RageBuff()
        {
            // 쿨타임 0일 때만 사용 가능
            if (cooltime < 1)
            {
                Debug.Log(">> 플레이어는 분노 버프를 사용했다!");
                Debug.Log(">> 온몸에 힘이 넘쳐 흐른다!");
                Debug.Log(">> 3턴 간 플레이어의 공격력이 3배가 된다!");
                atk *= 3;
                Debug.Log("-- 현재 공격력: " + atk);
                bufftime = 3;
                cooltime = 5;
                Debug.Log("-- 분노 재사용 가능까지 " + cooltime + "턴");
            }
            else Debug.Log(">> 분노 버프는 사용할 수 없습니다. 사용 가능까지 " + cooltime + "턴");
        }
        public void RageBuffOff()
        {
            // 공격력 돌아옴
            bufftime = 0;
            atk = defaultAtk;
        }

        // 보상
        public void Award(Unit unit)
        {
            Debug.Log("++ " + name + "는 전투에서 승리하고 " + unit.gold + "의 골드와 " + unit.exp + "의 경험치를 얻었다!");
            gold += unit.gold;
            exp += unit.exp;
            Debug.Log("++ 현재 골드: " + gold + " | 현재 경험치: " + exp);
            carma++;
        }

        public override void Death()
        {
            playerLife--;
            Debug.Log("++ " + name + "가 사망했다!");
            Debug.Log("++ " + name + "는 지금까지 " + carma + "마리의 몬스터를 잡았다.");
            Debug.Log("++ 수고하셨습니다.");
        }

        public override void UpdateState()
        {
            // 체력 넘치기 방지
            if (hp > max_hp)
                hp = max_hp;
            // 체력 마이너스 방지
            if (hp < 0)
                hp = 0;
            // 현재 체력 출력
            Debug.Log("-- " + name + "의 현재 체력: " + hp);
            
            // 버프 쿨타임중이면 깎기
            if (cooltime > 0)
            {
                Debug.Log("-- 분노 버프 사용 가능까지 " + cooltime + "턴");
                cooltime--;
            }
            // 버프 지속중이면 깎기
            if (bufftime > 0)
            {
                Debug.Log("-- 분노 버프 지속 시간이 " + bufftime + "턴 남았다.");
                bufftime--;
            }
            // 버프 지속 끝났으면 효과 풀기
            else RageBuffOff();
        }

    }

    // 몬스터 클래스
    public class Monster : Unit
    {
        int numberOfMonster = 0;

        public Monster(int _atk, int _def, int _hp, int _max_hp, int _agi, int _dex, int _gold, int _exp)
        {
            name = "몬스터" + numberOfMonster;
            atk = _atk;
            def = _def;
            hp = _hp;
            max_hp = _max_hp;
            agi = _agi;
            dex = _dex;
            gold = _gold;
            exp = _exp;
        }

        // 초기 상태로
        public override void Initialize()
        {
            numberOfMonster++;
            name = "몬스터" + numberOfMonster;
            atk = (int)(atk * 1.1f);
            def = (int)(def * 1.1f);
            max_hp = (int)(max_hp * 1.1f);
            hp = max_hp;
            agi = (int)(agi * 1.1f);
            dex = (int)(dex * 1.1f);
            gold += 500;
            exp += 500;
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
                Debug.Log(">>>> " + unit.name + "는 공격을 받았다.");
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
                unit.hp -= (int)(1.5f * atk) - unit.def;
                Debug.Log(">>>> " + unit.name + "는 급소에 공격을 받았다!");
            }
            else
                Debug.Log(">>>> 그러나 " + unit.name + "는 피했다!");
            unit.UpdateState();
        }
    }


    // 유닛 생성: 이름, 공격력, 방어력, HP, 최대HP, 회피, 크리율, 돈, 경험치
    public Player player = new Player("플레이어", 100, 30, 1000, 1000, 25, 30, 0, 0);
    public Monster monster = new Monster(150, 30, 1000, 1000, 33, 30, 500, 500);

    // 랜덤 시드
    int RandMIN = 0;
    int RandMAX = 100; // 
    int firstRandom = 0; // 선제 행동 카운트

    // 전투 플래그
    bool battleFlag = true;

    // 카운터 (그냥 넣어봄 ㅎ)
    int battleCount = 0;

    // 전투 다시 시작
    void BattleInitialize()
    {
        // 모든 변수 초기 상태로!
        // 배틀 플래그, 모든 쿨타임, 새로운 몬스터, 모든 플레이어 상태 초기화
        battleFlag = true;
        player.Initialize();
        monster.Initialize();
    }

    void PlayerDo(int button)
    {
        switch (button)
        {
            case 0:
                player.AttakToUnit(monster);
                break;
            case 1:
                player.SkillToUnit(monster);
                break;
            case 2:
                player.Healing();
                break;
            case 3:
                player.RageBuff();
                break;
        }
    }

    // 클릭시 발생
    private void Battle(int button)
    {
        // 전투 중 판단
        if (battleFlag)
        {
            // 턴 시작
            battleCount++;
            Debug.Log("==" + battleCount + "번째 턴 전투 개시!");

            // 전투
            firstRandom = Random.Range(RandMIN, RandMAX);
            if (firstRandom < 50)
            {
                // 플레이어 선공
                PlayerDo(button);
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
                {
                    PlayerDo(button);
                }
            }

            // 전투 이후 사망 체크
            if (player.hp <= 0)
            {
                player.Death();
                battleFlag = false;
            }
            if (monster.hp <= 0)
            {
                monster.Death();
                player.Award(monster);
                battleFlag = false;
            }
        }
        else if (player.playerLife < 1)
        {
            Debug.Log("-- 모든 것이 끝났다...");
        }
        else
        {
            Debug.Log("-- 다음 몬스터가 나타났다!");
            Debug.Log("-- 이 몬스터는 방금 잡은 몬스터보다 모든 면에서 10% 더 강하다!");
            BattleInitialize();
        }

        LifeCheckToColor();
        Debug.Log("========================");
        Debug.Log("[평타: Q] [강타: W] [힐링: E] [분노버프: R]");
    }

    void LifeCheckToColor()
    {
        // 오브젝트 색상 갱신: 체력이 낮아질 수록 하양 -> 빨강
        float color = 1.0f * player.hp / player.max_hp;
        gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, color, color, 1.0f);
    }

    private void Start()
    {
        Debug.Log("전투 시뮬레이터에 오신 것을 환영합니다.");
        Debug.Log("[평타: Q] [강타: W] [힐링: E] [분노버프: R]");
    }

    private void Update()
    {
        // 유저의 버튼 입력 받기
        if (Input.GetKeyDown(KeyCode.Q)) Battle(0);
        else if (Input.GetKeyDown(KeyCode.W)) Battle(1);
        else if (Input.GetKeyDown(KeyCode.E)) Battle(2);
        else if (Input.GetKeyDown(KeyCode.R)) Battle(3);
    }

}
