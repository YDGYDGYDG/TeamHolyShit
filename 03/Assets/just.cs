

//  실습 #02  인벤토리 채우기 (중급)

// 클릭할 때 마다 몬스터가 죽었다고 치고
// 몬스터는 아이템을 1개 랜덤으로 드랍
// 드랍한 아이템은 자동으로 인벤토리로 들어가고
// 한 슬롯당 최대 9개까지 동일한 아이템을 스택할 수 있음
// 단, 장비는 한 슬롯에 한 스택만 가능
// 몬스터가 드랍하는 아이템
//  ㄴ고블린의 견갑, 소형물약, 연습용 칼
// 총 인벤토리 슬롯 : 7개 를 채우는데 몇 마리의 고블린을 잡아야 하는지 출력

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class just : MonoBehaviour
{
    List<string> itemList = new List<string>() { "고블린 견갑", "소형물약", "연습용칼" };
    List<string> inventory = new List<string>();
    List<string> inven_item01 = new List<string>();
    List<string> inven_item02 = new List<string>();


    int item01 = 0;
    int item02 = 0;
    int item03 = 0;
    int totalItem;
    int inventoryNum = 0;
    int clickNum = 0;




    private void OnMouseDown()
    {
        clickNum++;
        int dropitem = Random.Range(0, 3);
        if (inventoryNum == 7 && inven_item01.Count == 9 && inven_item02.Count == 9)
        {
            totalItem = item01 + item02 + item03;
            Debug.Log("★인벤토리가 완벽하게 가득 찼습니다★");
            Debug.Log("처치한 몬스터 수 : " + clickNum);
        }
        else
        {
            if (inventoryNum == 7)
            {
                if (dropitem == 0 && inven_item01.Count == 9)
                {
                    Debug.Log("인벤토리가 가득 찼습니다");
                    Debug.Log(itemList[dropitem] + "을 획득하지 못합니다");
                }
                else if (dropitem == 0 && inven_item01.Count != 9)
                {
                    inven_item01.Add(itemList[dropitem]);
                    Debug.Log(itemList[dropitem] + "획득");
                }
                else if (dropitem == 1 && inven_item02.Count == 9)
                {
                    Debug.Log("인벤토리가 가득 찼습니다");
                    Debug.Log(itemList[dropitem] + "을 획득하지 못합니다");
                }
                else if (dropitem == 1 && inven_item02.Count != 9)
                {
                    inven_item02.Add(itemList[dropitem]);
                    Debug.Log(itemList[dropitem] + "획득");
                }
                else if (dropitem == 2)
                {
                    Debug.Log("인벤토리가 가득 찼습니다");
                    Debug.Log(itemList[dropitem] + "을 획득하지 못합니다");
                }
            }
            else
            {
                Debug.Log(" 몬스터 처치 ! ");
                inventory.Add(itemList[dropitem]);
                Debug.Log(itemList[dropitem] + "획득");

                if (dropitem == 0)
                {
                    item01++;
                    if (inven_item01.Count == 9)
                    {
                        inven_item01.Clear();
                        inventoryNum += 1;
                        inven_item01.Add(itemList[dropitem]);
                    }
                    else
                    {
                        if (item01 == 1)
                        {
                            inventoryNum += 1;
                        }
                        inven_item01.Add(itemList[dropitem]);
                    }
                }
                else if (dropitem == 1)
                {
                    item02++;
                    if (inven_item02.Count == 9)
                    {
                        inven_item02.Clear();
                        inventoryNum += 1;
                        inven_item02.Add(itemList[dropitem]);
                    }
                    else
                    {
                        if (item02 == 1)
                        {
                            inventoryNum += 1;
                        }
                        inven_item02.Add(itemList[dropitem]);
                    }
                }
                else
                {
                    item03++;
                    inventoryNum += 1;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}