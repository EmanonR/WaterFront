using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
