using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study34 : MonoBehaviour
{
    // foreach문
    // 배열에 순차적인 접근을 위해 사용

    List<int> itemList = new List<int>() { 4, 8, 12, 20, 36 };


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < itemList.Count; i++) 
        //{

        //}

        //foreach(int num in itemList)
        //{
        //    // num은 itemList의 모든 요소를 한 번 씩 들르게 됨
        //    switch (num)
        //    {

        //    }
        //}

        /* 실습
         * 인벤토리에 30개의 장비가 있고 1~6성까지 등급 랜덤 있다.
         * 3성 이하 잡템을 일괄 판매하는 기능 제작하기
         * 
         * 
        */

        // 1~6성 저장하는 템창
        //int[] inventoryStar = new int[30];

        //FullInventory(inventoryStar);
        //SellPooItems(inventoryStar);


    }

    void FullInventory(int[] inventory)
    {
        int randomSeed;
        //foreach (int i in inventory)
        //{
        //    randomSeed = Random.Range(1, 7);
        //    inventory[i] = randomSeed;
        //}
        for(int i=0; i< inventory.Length; i++)
        {
            randomSeed = Random.Range(1, 7);
            inventory[i] = randomSeed;
        }
        Debug.Log("1~6성 까지의 아이템 30개 랜덤 지급 완료");
    }

    void SellPooItems(int[] inventory)
    {
        int sellResult = 0;
        int sellCount = 0;
        int sell1StarCount = 0;
        int sell2StarCount = 0;
        int sell3StarCount = 0;
        Debug.Log("1~3성 까지의 잡템을 전부 매각합니다.");
        Debug.Log("1성: 100원");
        Debug.Log("2성: 200원");
        Debug.Log("3성: 300원");
        foreach (int i in inventory)
        {
            if (inventory[i] < 4)
            {
                switch (inventory[i])
                {
                    case 1:
                        sellResult += 100;
                        sellCount++;
                        sell1StarCount++;
                        break;
                    case 2:
                        sellResult += 200;
                        sellCount++;
                        sell2StarCount++;
                        break;
                    case 3:
                        sellResult += 300;
                        sellCount++;
                        sell3StarCount++;
                        break;
                }
            }
        }
        Debug.Log(sellCount + "개의 아이템을 매각했습니다.");
        Debug.Log("1성 " + sell1StarCount + "개");
        Debug.Log("2성 " + sell2StarCount + "개");
        Debug.Log("3성 " + sell3StarCount + "개");
        Debug.Log(sellResult + "원을 받았습니다.");
    }



    //=======================================================
    /*
     * 실습2
     * 인벤토리 채우기
     * 클릭 할 때 마다 몬스터가 죽었다고 치고
     * 아이템을 드랍해 인벤토리에 들어간다.
     * 한 슬롯 당 최대 9개 까지 동일한 아이템이 쌓인다.
     * 장비의 경우 슬롯 당 1개만 쌓인다.
     * { 고블린의 견갑(재료), 소형물약(소모품), 연습용 칼(장비) } 
     * 총 슬롯 7개.
     * 7개를 전부 채우는 데 잡은 고블린의 숫자 출력
    */

    static int MAXIMUMSLOT = 7;
    
    int[] inventorySlot = new int[7] { 3, 3, 3, 3, 3, 3, 3 }; // 타입 저장고
    int[] inventorySlotNumbers = new int[7] { 0, 0, 0, 0, 0, 0, 0 }; // 개수 저장고
    string[] itemName = new string[4] { "고블린의 견갑", "소형 물약", "연습용 칼", "없음" };
    int nowSlot = 0;

    int MAXIMUMITEM = 9;
    int killCount = 0;

    void GetRewardItems(int[] inventory, int[] numbers)
    {
        killCount++;
        int randomSeed = Random.Range(0, 3);
        switch (randomSeed)
        {
            case 0:
                Debug.Log("고블린을 찢었다.");
                break;
            case 1:
                Debug.Log("고블린을 뿌셨다.");
                break;
            case 2:
                Debug.Log("고블린을 죽였다.");
                break;
        }

        bool rusrkqflag = true;
        bool anfdirflag = true;

        // 무슨 템을 얻었나?
        randomSeed = Random.Range(0, 3);
        switch (randomSeed)
        {
            case 0:
                Debug.Log("고블린의 견갑을 획득했다!");
                // inventory 0번째 칸부터 끝까지 살펴보자
                if(rusrkqflag == true)
                {
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        // inventory에 이미 견갑이 있는 칸이 있는지 확인
                        if (inventory[i] == 0)
                        {
                            // 있으면 9개 미만인지 numbers 확인 
                            if (numbers[i] < MAXIMUMITEM)
                            {
                                // 미만이면 그inventory칸에 넣고 numbers개수 +1
                                numbers[i]++;
                                rusrkqflag = false;
                                break;
                            }
                        }
                    }
                }
                // 견갑이 아예 없으면 빈inventory칸에 넣고 numbers개수 +1
                // 칸도 하나 차지했으니 현재 사용하고 있는 칸 개수 +1
                // 이때 칸이 이미 풀칸이면 그냥 버려야 함
                if (rusrkqflag == true)
                {
                    if (nowSlot < MAXIMUMSLOT)
                    {
                        inventory[nowSlot] = 0;
                        numbers[nowSlot]++;
                        nowSlot++;
                        Debug.Log("나우슬롯올렸다"+nowSlot);
                    }
                }
                rusrkqflag = true;
                break;
            case 1:
                Debug.Log("소형물약을 획득했다!");
                // 견갑과 동일. 타입을 0에서 1로
                if (anfdirflag == true)
                {
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == 1)
                        {
                            if (numbers[i] < MAXIMUMITEM)
                            {
                                numbers[i]++;
                                anfdirflag = false;
                                break;
                            }
                        }
                    }
                }
                if (anfdirflag == true)
                {
                    if (nowSlot < MAXIMUMSLOT)
                    {
                        inventory[nowSlot] = 1;
                        numbers[nowSlot]++;
                        nowSlot++;
                        Debug.Log("나우슬롯올렸다" + nowSlot);
                    }
                }
                anfdirflag = true;
                break;
            case 2:
                Debug.Log("연습용 칼을 획득했다!");
                // 무조건 빈 칸에 넣는다
                if (nowSlot < MAXIMUMSLOT)
                {
                    inventory[nowSlot] = 2;
                    numbers[nowSlot]++;
                    nowSlot++;
                    Debug.Log("나우슬롯올렸다" + nowSlot);
                    break;
                }
                break;

        }

        Debug.Log(nowSlot);
        Backpack();
    }

    private void OnMouseDown()
    {
        if (FullCheck())
            // 가방 덜 찼으면 채워
            GetRewardItems(inventorySlot, inventorySlotNumbers);
        else
        {
            Debug.Log("인벤토리 7칸을 모두 꽉 채웠다!");
            Debug.Log("당신은 지금까지 " + killCount + "마리의 고블린을 무참히 죽였다.");
            // 각 칸에 무엇이 몇 개 들어있는지 출력
            Backpack();
        }

    }

    void Backpack()
    {
        Debug.Log("====당신의 가방 내용물====");
        for (int i = 0; i < MAXIMUMSLOT; i++)
        {
            Debug.Log(i + "번째 칸: " + itemName[inventorySlot[i]] + ", " + inventorySlotNumbers[i] + "개");
        }
        Debug.Log("==========================");
    }

    bool FullCheck()
    {
        for (int i = 0; i < inventorySlot.Length; i++)
        {
            if(inventorySlot[i] == 0 || inventorySlot[i] == 1)
            {
                if (inventorySlotNumbers[i] != 9)
                    return true;
            }
        }
        if (inventorySlot[0] == 3)
            return true;

        return false;
    }

}
