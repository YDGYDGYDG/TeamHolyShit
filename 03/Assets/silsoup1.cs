using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silsoup1 : MonoBehaviour
{
    public string pcName;
    public int pcRank;
    public string[] pcItems  = new string[6];
    public int pcRelationship;
    public int pcLevel;
    public int pcEXP;
    public int pcMaxEXP;
    public int pcTalent;
    public bool pcPrivateW;
    public int pcPrivateWLevel;
    public int pcPrivateWMaxLevel;
    public int pcEfficiency; //투력
    public int pcPhysicalAtk;
    public int pcPhysicalDef;
    public int pcMagicalAtk;
    public int pcMagicalDef;
    public int pcHP;
    public int pcPhysicalCri;
    public int pcMagicalCri;
    public int pcAvoid;
    public int pcHPRegen;
    public int pcTPRegen;
    public int pcHPAbsorb;
    public int pcRecovery;
    public int pcTPUp;
    public int pcTPSave;
    public int pcAccuracy; // 명중

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("이름: "+pcName);
        Debug.Log("랭크: "+ pcRank);
        Debug.Log("아이템1: "+ pcItems[0]);
        Debug.Log("아이템2: "+ pcItems[1]);
        Debug.Log("아이템3: "+ pcItems[2]);
        Debug.Log("아이템4: "+ pcItems[3]);
        Debug.Log("아이템5: "+ pcItems[4]);
        Debug.Log("아이템6: " + pcItems[5]);
        Debug.Log("인연랭크: "+ pcRelationship);
        Debug.Log("레벨: "+ pcLevel);
        Debug.Log("경험치: "+ pcEXP);
        Debug.Log("경험치: "+ pcMaxEXP);
        Debug.Log("재능 개화: "+ pcTalent);
        if (pcPrivateW == true)
            Debug.Log("전용장비: 있음");
        else
            Debug.Log("전용장비: 없음");
        Debug.Log("전장 레벨: "+ pcPrivateWLevel);
        Debug.Log("전장 확장 레벨: "+ pcPrivateWMaxLevel);
        Debug.Log("전투력: "+ pcEfficiency);
        Debug.Log("물리공격력: "+ pcPhysicalAtk);
        Debug.Log("물리방어력: "+ pcPhysicalDef);
        Debug.Log("마법공격력: "+ pcMagicalAtk);
        Debug.Log("마법방어력: "+ pcMagicalDef);
        Debug.Log("HP: "+ pcHP);
        Debug.Log("물리크리티컬: "+ pcPhysicalCri);
        Debug.Log("마법크리티컬: "+ pcMagicalCri);
        Debug.Log("회피: "+ pcAvoid);
        Debug.Log("HP자동회복: "+ pcHPRegen);
        Debug.Log("TP자동회복: "+ pcTPRegen);
        Debug.Log("HP흡수: "+ pcHPAbsorb);
        Debug.Log("회복량: "+ pcRecovery);
        Debug.Log("TP상승: "+ pcTPUp);
        Debug.Log("TP소비감소: "+ pcTPSave);
        Debug.Log("명중: "+ pcAccuracy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
