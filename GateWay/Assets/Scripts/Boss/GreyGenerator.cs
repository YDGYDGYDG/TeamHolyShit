using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGenerator : MonoBehaviour
{
  //  float time;  // 경과 시간
  //  float WallReset; // 벽 초기화
  //  public float ATime = 1.0f;
  //  public float BTime = 1.0f;
  //  public GameObject rlr;
  //  public GameObject rlb;
  //  public GameObject udr;
  //  public GameObject udb;
  //
  //
  //  // Start is called before the first frame update
  //  void Start()
  //  {
  //
  //
  //  }
  //
  //  void AWalls()
  //  {
  //      Bwall1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
  //      Bwall1.GetComponent<BoxCollider2D>().isTrigger = true;
  //      Bwall1.gameObject.tag = "Untagged";
  //  }
  //  void BWalls()
  //  {
  //      Bwall1.GetComponent<SpriteRenderer>().material.color = Color.white;
  //      Bwall1.GetComponent<BoxCollider2D>().isTrigger = false;
  //      Bwall1.gameObject.tag = "Wall";
  //  }
  //  // Update is called once per frame
  //  void Update()
  //  {
  //      WallReset = BTime + ATime;
  //
  //      time += Time.deltaTime;
  //      if (time < ATime)
  //          AWalls();
  //      if (time >= BTime)
  //          BWalls();
  //
  //      if (time > WallReset)
  //          time = 0;
  //  }
}
