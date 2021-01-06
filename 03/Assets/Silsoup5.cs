using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silsoup5 : MonoBehaviour
{
    // 강화 시스템
    /*
     * 강화 단계가 올라갈 수록 이전 단계의 80%확률로 성공률이 줄어든가
     * 최초 성공률 100%
     * 최대 강화 단계 10
     * 강화 10단계에 도달한 횟수를 체크한다.
     * 10개의 강화 10단계를 제작하는 데 소요된
     * 1. 총 강화 횟수
     * 2. 평균 강화 횟수
     * 를 출력하라.
     */

    int reinLevel = 1;

    // 횟수
    int reinTimes = 0;
    // 총 횟수
    int totalReinTimes = 0;
    // 평균 횟수
    int aveReinTimes = 0;
    int[] aveSaver = new int[10];
    // 몇 번째 강화 작업인가
    int totalMajorReinTimes = 0;

    //강화 확률
    int sucRate = 100;
    int sucRand;

    private void OnMouseDown()
    {

        while (totalMajorReinTimes < 10)
        {
            Debug.Log("===============================");
            Debug.Log((totalMajorReinTimes+1) + "번째 무기 강화 시작합니다.");
            while (reinLevel < 10)
            {
                Reinforcement();
            }
            aveSaver[totalMajorReinTimes] = reinTimes;
            totalMajorReinTimes++;
            init();
        }

        if (totalMajorReinTimes >= 10)
        {
            for(int i=0; i<10; i++)
            {
                aveReinTimes += aveSaver[i];
            }
            aveReinTimes = (int)(aveReinTimes / 10);

            Debug.Log("===============================");
            Debug.Log("10개의 10강 무기를 획득했습니다.");
            Debug.Log("강화 시스템 종료");
            Debug.Log("총 강화 시도 횟수: " + totalReinTimes);
            Debug.Log("평균 강화 시도 횟수: " + aveReinTimes);
        }
    }

    void Reinforcement()
    {
        Debug.Log("===============================");
        Debug.Log((reinTimes + 1) + "번째 강화를 실시합니다.");
        Debug.Log("현재 강화 레벨: " + reinLevel);
        Debug.Log("현재 강화 확률: " + sucRate + " %");
        Debug.Log("-------------------------------");

        sucRand = Random.Range(0, 100);
        if (sucRand < sucRate)
        {
            Debug.Log("강화 성공!");
            reinLevel++;
            Debug.Log("현재 강화 레벨: " + reinLevel);
            Debug.Log("강화 확률이 조정됩니다.");
            sucRate = (int)(sucRate * 0.8);
        }
        else
        {
            Debug.Log("강화 실패..");
        }

        reinTimes++;
        totalReinTimes++;

        //Debug.Log("-------------------------------");
        //Debug.Log("===============================");
    }

    void init()
    {
        reinLevel = 1;
        reinTimes = 0;
        sucRate = 100;
    }
}

