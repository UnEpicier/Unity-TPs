using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int _score = 0;
    public int Score {
        get { return _score; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _score++;
        }
    }
}
