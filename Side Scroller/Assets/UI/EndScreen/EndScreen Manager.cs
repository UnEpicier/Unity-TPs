using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActiveAndEnabled)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
