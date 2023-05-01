using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunBabyWinTriggerController : MonoBehaviour
{
    public GameObject fireSystem;
    public bool isWon = false;
    private float isWonTimer = 0f;
    public GameObject winText;
    private bool didFoom = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireSystem.transform.position = transform.position;
        if (isWon)
        {
            isWonTimer -= Time.deltaTime;
            if (isWonTimer < 5f)
            {
                fireSystem.SetActive(true);
                if (!didFoom)
                {
                    didFoom = true;
                    GetComponent<AudioSource>().Play();
                }
                winText.SetActive(true);
            }
            if (isWonTimer <= 0f)
            {
                SceneManager.LoadScene("TransitionScene");
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GunBabyWinTrigger"))
        {
            isWon = true;
            isWonTimer = 10f;
        }
    }

}
