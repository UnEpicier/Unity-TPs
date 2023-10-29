using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void DisplayOptions()
    {
        SceneManager.LoadScene("Options Screen", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
