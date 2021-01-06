using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study33 : MonoBehaviour
{
    // 리스트

    int[] numA = new int[5];


    /* 배열과의 차이점
    


    */
    // 리스트 생성
    List<int> itemList = new List<int>();
    // 리스트 개수 지정 생성
    List<int> itemList2 = new List<int>(new int[30]) { 1, 2, 3 };
    // 빈 30개의 int 리스트와 1, 2, 3이 들어있는 3개의 리스트가 추가되어 33개의 리스트가 작성됨
    // #초기화 리스트는 마지막에 생성된다.

    private void Start()
    {
        numA[0] = 36;

        // 리스트에서 데이터를 추가하기
        itemList.Add(1); // 그냥 쑤셔넣으면 0번 위치에서부터 들어가기 시작함
        itemList.Add(2);
        itemList.Add(3);
        itemList.Add(4);
        itemList.Add(5); // -> { 1, 2, 3, 4, 5 }

        // 호출 방식은 배열과 같다.
        Debug.Log(itemList[1]);

        // 리스트 원하는 위치에 값 추가
        itemList.Insert(2, 50); // -> { 1, 2, 50, 3, 4, 5 }
        // insert를 하면 원래 2번 위치에 있던 값과 그 뒤에 값들을 한 칸씩 뒤로 밀어남

        // 원하는 위치 값 변화
        itemList[2] = 10; //단순대입 -> { 1, 2, 10, 3, 4, 5 }
        

        // 여러 개의 요소가 있는 배열, 리스트를 관리할 때는 반복문을 사용하는 게 어떨까?
        for (int i = 0; i < numA.Length; i++) { }
        for (int i = 0; i < itemList.Count; i++) { }

        // 들어간 요소를 삭제하는 방법
        itemList.Remove(2); // 처음부터 검색해서 2를 찾으면 그 순간 걔를 삭제, 뒤를 땡긴다 -> { 1, 10, 3, 4, 5 }
        itemList.RemoveAt(2); // 2번째 놈을 삭제하고 뒤를 땡긴다 -> { 1, 10, 4, 5 }

        Debug.Log(itemList[1]);
        Debug.Log(itemList[2]); // 이제 2번째를 뽑으면? 10이겠지

        // 특수한 조건으로 요소를 삭제하기
        // 람다식 사용
        itemList.RemoveAll(야호야호 => 야호야호 > 9); // 리스트 전체에서 임의값이 9 초과이면 제거
        // 람다식 => 이전에 부른 변수명은 int 변수명이 생략된 것: int 야호야호


        // 다죽여~
        itemList.Clear();
    }


}
