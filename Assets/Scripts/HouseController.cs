using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public int houseNumber;
    public bool packageDelivered;

    private void Start()
    {
        packageDelivered = false;
    }
}