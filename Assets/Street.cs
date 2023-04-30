using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    private float dz = 0f;
    private Vector3 orig;

    void Start()
    {
        orig = transform.position;
    }

    void Update()
    {
        dz += Time.deltaTime * 500f;
        if (dz > 200f)
        {
            dz -= 200f;
        }

        transform.position = orig + new Vector3(0f, 0f, -dz);
        
    }
}
