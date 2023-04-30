using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGunbaby : MonoBehaviour
{
    public GameObject followTarget;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(
            followTarget.transform.position.x,
            followTarget.transform.position.y,
            -10f
        );
    }
}
