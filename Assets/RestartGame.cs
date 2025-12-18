using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartCurrentScnene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
