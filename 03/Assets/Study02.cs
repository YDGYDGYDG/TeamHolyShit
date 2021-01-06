using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study02 : MonoBehaviour
{
    // 유니티 데이터 타입
    // 유니티에서 제공하는 독자적인 데이터 타입
    GameObject monster;         // GameObject 클래스 담는 타입
    Transform mstTransform;     // 컴포넌트 담는 타입
    Rigidbody mstRigidBody;     //
    Collider mstCollider;       //

    // 참조 형식의 이해
    // C#에서 제공하는 기본적인 int 등의 데이터 타입에 변수를 담으면
    // 내가 넣은 값이 실제 데이터로써 들어가 있는 직관적인 방법
    // 하지만
    // 실제 데이터가 아니라 해당 데이터가 담겨져 있는 곳에 접근하도록 하는
    // 간접 접근 방법을 지정하는 것

    void Start()
    {
        GameObject monster1 = GameObject.Find("Monster");
        GameObject monster2 = GameObject.Find("Monster");
        GameObject monster3 = GameObject.Find("Monster");
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
