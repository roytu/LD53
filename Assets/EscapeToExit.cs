using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToExit : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TransitionScene");
        }
    }
}
