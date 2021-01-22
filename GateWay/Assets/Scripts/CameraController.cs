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
    }
}
