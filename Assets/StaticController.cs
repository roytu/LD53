using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticController : MonoBehaviour
{
    private float t = 0;
    private bool isDone = false;

    void Update()
    {
        t += Time.deltaTime;
        if (t > 1f && !isDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            isDone = true;
        }
    }
}
