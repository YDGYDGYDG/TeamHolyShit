using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float heightMax = 100;
    public float heightMin = -100;
    public float widthMax = 100;
    public float widthMin = -100;

    public Transform playerTransform;

    public float smoothSpeed = 0.9f;
    Vector3 smoothedPosition;

    void FixedUpdate()
    {
        smoothedPosition = Vector3.Lerp(playerTransform.position, transform.position, smoothSpeed);

        if (transform.position.x < widthMax && transform.position.x > widthMin && transform.position.y < heightMax && transform.position.y > heightMin)
        {
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
        // 전부 이탈
        // XY 초과
        else if (transform.position.x >= widthMax && transform.position.y >= heightMax)
        {
            transform.position = new Vector3(widthMax, heightMax, transform.position.z);
            if (playerTransform.position.x <= widthMax)
                transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            if (playerTransform.position.y <= heightMax)
                transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        }
        // XY 미만
        else if (transform.position.x <= widthMin && transform.position.y <= heightMin)
        {
            transform.position = new Vector3(widthMin, heightMin, transform.position.z);
            if (playerTransform.position.x >= widthMin)
                transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            if (playerTransform.position.y >= heightMin)
                transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);

        }
        // X초과 Y미만
        else if (transform.position.x >= widthMax && transform.position.y <= heightMin)
        {
            transform.position = new Vector3(widthMax, heightMin, transform.position.z);
            if (playerTransform.position.x <= widthMax)
                transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            if (playerTransform.position.y >= heightMin)
                transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);

        }
        // X미만 Y초과
        else if (transform.position.x <= widthMin && transform.position.y >= heightMax)
        {
            transform.position = new Vector3(widthMin, heightMax, transform.position.z);
            if (playerTransform.position.x >= widthMin)
                transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            if (playerTransform.position.y <= heightMax)
                transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);

        }
        // X 이탈
        else if (transform.position.x >= widthMax)
        {
            transform.position = new Vector3(widthMax, smoothedPosition.y, transform.position.z);
            if (playerTransform.position.x <= widthMax)
                transform.position = new Vector3(playerTransform.position.x, smoothedPosition.y, transform.position.z);
        }
        else if (transform.position.x <= widthMin)
        {
            transform.position = new Vector3(widthMin, smoothedPosition.y, transform.position.z);
            if (playerTransform.position.x >= widthMin)
                transform.position = new Vector3(playerTransform.position.x, smoothedPosition.y, transform.position.z);
        }
        // Y 이탈
        else if (transform.position.y >= heightMax)
        {
            transform.position = new Vector3(smoothedPosition.x, heightMax, transform.position.z);
            if (playerTransform.position.y <= heightMax)
                transform.position = new Vector3(smoothedPosition.x, playerTransform.position.y, transform.position.z);
        }
        else if (transform.position.y <= heightMin)
        {
            transform.position = new Vector3(smoothedPosition.x, heightMin, transform.position.z);
            if (playerTransform.position.y >= heightMin)
                transform.position = new Vector3(smoothedPosition.x, playerTransform.position.y, transform.position.z);
        }
        else
        {
            Debug.Log("카메라 오류");
        }
    }
}
