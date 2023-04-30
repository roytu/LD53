using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public float t = 0;
    public GameObject warningImage;
    public float warningTimer = 0f;

    public bool[] wasSpawned = {
        false,
        false,
        false
    };

    void Start()
    {
        warningImage.SetActive(false);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > 3f && !wasSpawned[0])
        {
            wasSpawned[0] = true;
            SpawnCar();
        }
        if (t > 10f && !wasSpawned[1])
        {
            wasSpawned[1] = true;
            SpawnCar();
        }
        if (t > 15f && !wasSpawned[2])
        {
            wasSpawned[2] = true;
            SpawnCar();
        }

        warningTimer -= Time.deltaTime;
        if (warningTimer <= 0f)
        {
            warningImage.SetActive(false);
        }
    }

    void SpawnCar()
    {
        Instantiate(car, transform.position, Quaternion.identity);
        warningTimer = 2f;
        warningImage.SetActive(true);
    }
}
