using System;
using UnityEngine;

public class Vial : MonoBehaviour
{
    public int numDrops = 0;
    public int maxNumDrops = 0;

    private void Update()
    {
        numDrops = 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ++numDrops;
        maxNumDrops = Math.Max(numDrops, maxNumDrops);
    }
}
