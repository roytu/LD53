using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public float t = 0;
    public GameObject warningImage;
    public float warningTimer = 0f;

    public List<bool> wasSpawned;
    public GameObject particleSystem;

    public enum State
    {
        PLAYING,
        WON,
        DEAD
    };
    public State state = State.PLAYING;

    public GameObject deathText;
    public GameObject winText;

    void Start()
    {
        wasSpawned = new List<bool>();
        wasSpawned.Add(false);
        wasSpawned.Add(false);
        wasSpawned.Add(false);
        wasSpawned.Add(false);
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
            GetComponent<AudioSource>().Play();
            particleSystem.SetActive(true);
        }
    }
}
