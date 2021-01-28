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
    private BoxCollider collider;
    private Vector3 collider_size;
    private Vector3 collider_centre;
    void Start()
    {
        SpawnPuzzle(7);
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
        //둘째줄
        puzzleList[2].transform.position = new Vector3(startPosition.x, startPosition.y-(2 * offset.y), 0.0f);
        puzzleList[3].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        puzzleList[4].transform.position = new Vector3(startPosition.x + (4 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
        //셋째줄
        puzzleList[5].transform.position = new Vector3(startPosition.x, startPosition.y - (4 * offset.y), 0.0f);
        puzzleList[6].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (4 * offset.y), 0.0f);
        puzzleList[7].transform.position = new Vector3(startPosition.x + (4 * offset.x), startPosition.y - (4 * offset.y), 0.0f);
    }

    void MovePuzzle()
    {
        foreach (PicturePuzzle picturePuzzle in puzzleList)
        {
            picturePuzzle.move_amount = offset;

            if(picturePuzzle.clicked)
            {
                collider = picturePuzzle.GetComponent<BoxCollider>();
                collider_size = collider.size;
                collider_centre = collider.center;

                float move_amount = offset.x;
                float direction = Mathf.Sign(move_amount);

                float x = (picturePuzzle.transform.position.x + collider_centre.x - collider_centre.x / 2) + collider_size.x / 2;
                float y_up = picturePuzzle.transform.position.y + collider_centre.y + collider_size.y / 2 + direction;
                float y_down = picturePuzzle.transform.position.y + collider_centre.y + collider_size.y / 2 - direction;

                ray_up = new Ray(new Vector2(x, y_up), new Vector2(0, direction));
                ray_down = new Ray(new Vector2(x, y_down), new Vector2(0, -direction));

                Debug.DrawRay(ray_up.origin, ray_up.direction);
                Debug.DrawRay(ray_down.origin, ray_down.direction);

                float y = (picturePuzzle.transform.position.y + collider_centre.y - collider_size.y/2) + collider_size.y / 2;
                float x_right = picturePuzzle.transform.position.x + collider_centre.x + collider_size.x / 2 * direction;
                float x_left = picturePuzzle.transform.position.x + collider_centre.x + collider_size.x / 2 * -direction;

                ray_left = new Ray(new Vector2(x_left, y), new Vector2(direction, 0f));
                ray_right = new Ray(new Vector2(x_right, y), new Vector2(-direction, 0f));

                Debug.DrawRay(ray_left.origin, ray_left.direction);
                Debug.DrawRay(ray_right.origin, ray_right.direction);

                if((Physics.Raycast(ray_up, out hit, 1.0f, collisionMask) == false) && (picturePuzzle.moved ==false) && (picturePuzzle.transform.position.y < startPosition.y))
                {
                    Debug.Log("Move Up Allowed");
                    picturePuzzle.go_up = true;
                }
                if ((Physics.Raycast(ray_down, out hit, 1.0f, collisionMask) == false) && (picturePuzzle.moved == false) && (picturePuzzle.transform.position.y > startPosition.y -3))
                {
                    Debug.Log("Move Down Allowed");
                    picturePuzzle.go_down = true;
                }
                if ((Physics.Raycast(ray_left, out hit, 1.0f, collisionMask) == false) && (picturePuzzle.moved == false) && (picturePuzzle.transform.position.x > startPosition.x))
                {
                    Debug.Log("Move Down Allowed");
                    picturePuzzle.go_down = true;
                }



            }
        }


    }


}
