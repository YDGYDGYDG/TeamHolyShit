using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study32 : MonoBehaviour
{
    int[] itemslot = new int[30];
    string[] itemslotName = new string[30];
    int[] itemslotPrice = new int[30];
    int[] itemID = new int[4] { 101, 102, 103, 104 };
    string[] itemName = new string[4] { "소형물약", "중형물약", "대형물약", "신의눈물" };
    int[] itemPrice = new int[4] { 100, 200, 400, 10000 };


    // 실습
    // 아이템슬롯 30개에 4가지 물약 중 하나를 임의로 넣기
    // 15번째 슬롯에 어떤 물약이 있는지 출력
    // 인벤토리 모든 물약 값의 합을 출력


    void Start()
    {
        int randomValue;

        for (int i=0; i<itemslot.Length; i++)
        {
            randomValue = Random.Range(0, 4);
            itemslot[i] = itemID[randomValue];
            itemslotName[i] = itemName[randomValue];
            itemslotPrice[i] = itemPrice[randomValue];
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("15번째 슬롯 내용물: " + itemslotName[14]);
        int price = 0;
        for (int i = 0; i < itemslot.Length; i++)
        {
            price += itemslotPrice[i];
        }
        Debug.Log("모든 물약 가격의 합: " + price);
    }
}
