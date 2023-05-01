using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        Debug.Log("ReloadScene called");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
