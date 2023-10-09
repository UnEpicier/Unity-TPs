using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Update()
    {
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y * -1;

        Debug.Log($"maxY: {maxY}  |  y: {transform.position.y}");

        if (transform.position.y <= maxY)
        {
            Time.timeScale = 0;
        }
    }
}
