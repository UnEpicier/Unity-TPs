using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Start Screen", LoadSceneMode.Single);
    }
}