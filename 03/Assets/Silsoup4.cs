using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silsoup4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Gugudan();
    }

    // 구구단 출력하기 
    void Gugudan()
    {
        int summary = 0;
        int oddCounter = 0;
        int fourCounter = 0;

        for (int i=2; i<10; i++)
        {
            for(int j=1; j<10; j++)
            {
                int result = i * j;
                Debug.Log(i + "X" + j + "=" + result);
                if ((int)(result / 10) == 4)
                {
                    fourCounter++;
                }
                if (result % 2 == 1)
                {
                    oddCounter++;
                }
                summary += result;

            }
            Debug.Log("---------------------------");
        }
        Debug.Log("===========================");

        Debug.Log("결과값의 합: " + summary);
        Debug.Log("결과값 중 홀수의 수: " + oddCounter);
        Debug.Log("10자리가 4인 결과값의 수: " + fourCounter);

    }


    // 11연차 뽑기
    // 큐브 클릭하면 연차 나온다
    // 3성 70%, 4성 20%, 5성 9%, 6성 1%
    // 최소 1장의 카드는 확정 5성
    // 

    int randomMin = 0;
    int randomMax = 100;
    int forStarRate = 20;
    int fivStarRate = 9;
    int sixStarRate = 1;

    int thrStar = 0;
    int forStar = 0;
    int fivStar = 0;
    int sixStar = 0;

    int resultRate;

    int timesGacha = 1;
    int totalSixStar = 0;
    bool isEndFlag = false;

    void Gotcha()
    {
        Debug.Log("===============================");
        Debug.Log("당신의 월급 데이터 쪼가리로 대체되었다.");

        // 10연차
        for (int i = 0; i < 10; i++) DrowCard();

        // 보너스 보정
        if(fivStar + sixStar < 1)
        {
            Debug.Log("보너스 연차가 발생했다!");
            resultRate = Random.Range(randomMin, randomMax);
            if (resultRate > 90)
            {
                Debug.Log("이럴리가 없는데? 당신은 6성 카드를 얻었다!");
                sixStar++;
                totalSixStar++;
            }
            else
            {
                Debug.Log("축하합니다! 당신은 5성 카드를 얻었다!");
                fivStar++;
            }
        }
        else
        {
            Debug.Log("보너스 연차가 발생하지 않았다.");
            DrowCard();
        }

        Debug.Log("-------------------------------");
        Debug.Log("+ 3성 카드: " + thrStar + "장 +");
        Debug.Log("+ 4성 카드: " + forStar + "장 +");
        Debug.Log("+ 5성 카드: " + fivStar + "장 +");
        Debug.Log("+ 6성 카드: " + sixStar + "장 +");
        Debug.Log("-------------------------------");
        Debug.Log("===============================");

        Init();
        timesGacha++;
    }

    private void OnMouseDown()
    {
        Debug.Log("당신은 " + timesGacha + "회 째 연차를 돌리고 있다.");
        Gotcha();
        if (totalSixStar >= 10 && isEndFlag == false)
        {
            isEndFlag = true;
            Debug.Log("당신은 " + timesGacha + "회 만에 6성 10장을 모았다! 흑우녀석!");
        }
    }

    void DrowCard()
    {
        resultRate = Random.Range(randomMin, randomMax);
        if (resultRate < sixStarRate)
        {
            Debug.Log("이럴리가 없는데? 당신은 6성 카드를 얻었다!");
            sixStar++;
            totalSixStar++;
        }
        else if (resultRate < sixStarRate + fivStarRate)
        {
            Debug.Log("축하합니다! 당신은 5성 카드를 얻었다!");
            fivStar++;
        }
        else if (resultRate < sixStarRate + fivStarRate + forStarRate)
        {
            Debug.Log("당신은 4성 카드를 얻었다!");
            forStar++;
        }
        else
        {
            Debug.Log("당신은ㅋㅋ 3성ㅋㅋ 카드를ㅋㅋ 얻ㅋ었ㅋ다!");
            thrStar++;
        }
    }

    void Init()
    {
        thrStar = 0;
        forStar = 0;
        fivStar = 0;
        sixStar = 0;
    }
}
