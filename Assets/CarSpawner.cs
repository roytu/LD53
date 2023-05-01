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
        false,
        false
    };

    public enum State
    {
        PLAYING,
        WON,
        DEAD
    };
    public State state = State.PLAYING;

    private GameObject deathText;
    private GameObject winText;

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
        if (t > 25f && !wasSpawned[3])
        {
            wasSpawned[3] = true;
            SpawnCar();
        }
        if (t > 30f)
        {
            Win();
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

    public void Die()
    {
        if (state == State.PLAYING)
        {
            state = State.DEAD;
            deathText.SetActive(true);
        }
    }
    public void Win()
    {
        if (state == State.PLAYING)
        {
            state = State.WON;
            winText.SetActive(true);
        }
    }
}
