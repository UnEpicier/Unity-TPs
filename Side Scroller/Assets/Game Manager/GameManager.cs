using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreen;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void ShowEndScreen()
    {
        endScreen.SetActive(true);
    }
}
