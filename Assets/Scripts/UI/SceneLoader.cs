using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
        if (GameManager.Instance != null)
            GameManager.Instance.DestroyMe();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
