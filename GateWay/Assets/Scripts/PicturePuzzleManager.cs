using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzleManager : MonoBehaviour
{
    public PicturePuzzle puzzlePrefab;

    private List<PicturePuzzle> puzzleList = new List<PicturePuzzle>();

    private Vector2 startPosition = new Vector2(-3.55f, 1.77f);
    private Vector2 offset = new Vector2(2.03f, 1.52f);

    // 퍼즐 움직이기
    public LayerMask collisionMask;
    // 충돌
    Ray ray_up, ray_down, ray_left, ray_right;
    RaycastHit hit;
    private BoxCollider2D collider;
    private Vector3 collider_size;
    private Vector3 collider_centre;
    void Start()
    {
        SpawnPuzzle(8);
        SetStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPuzzle(int number)
    {
        for(int i=0; i<= number; i++)
        {
            puzzleList.Add(Instantiate(puzzlePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity) as PicturePuzzle);
        }
    }

    void SetStartPosition()  
    {
        //첫줄
        puzzleList[0].transform.position = new Vector3(startPosition.x, startPosition.y, 0.0f);
        puzzleList[1].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y, 0.0f);
        puzzleList[2].transform.position = new Vector3(startPosition.x + (4 * offset.x), startPosition.y, 0.0f);
        //둘째줄
        puzzleList[3].transform.position = new Vector3(startPosition.x, startPosition.y-(2 * offset.y), 0.0f);
        puzzleList[4].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        puzzleList[5].transform.position = new Vector3(startPosition.x + (4 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        //셋째줄
        puzzleList[6].transform.position = new Vector3(startPosition.x, startPosition.y - (4 * offset.y), 0.0f);
        puzzleList[7].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (4 * offset.y), 0.0f);
        puzzleList[8].transform.position = new Vector3(startPosition.x + (4 * offset.x), startPosition.y - (4 * offset.y), 0.0f);
    }

    void MovePuzzle()
    {
        foreach (PicturePuzzle puzzle in puzzleList);
        {
            //puzzle.move_amount = offset;

            //if(PicturePuzzle.clicked)
        }


    }


}
