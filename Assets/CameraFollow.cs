using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;

    private float offsetY;
    void Start()
    {
        offsetY = transform.position.y - followTarget.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            followTarget.transform.position.y + offsetY,
            transform.position.z
        );
    }
}
