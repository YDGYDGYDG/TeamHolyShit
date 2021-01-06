using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silsoup7 : MonoBehaviour
{
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
                if (rusrkqflag == true)
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
                    break;
                }
                break;

        }

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
            if (inventorySlot[i] == 0 || inventorySlot[i] == 1)
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
