using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void FixedUpdate()
    {
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y * -1;

        if (transform.position.y <= maxY)
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ShowEndScreen();
        }
    }
}
