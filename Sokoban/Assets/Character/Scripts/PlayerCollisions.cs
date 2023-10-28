using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if it's a box
        if (collision.gameObject.CompareTag("Box"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;

            if (Mathf.Abs(direction.x) >  Mathf.Abs(direction.y))
            {
                if (direction.x > 0f)
                {
                    collision.transform.Translate(new Vector2(-0.64f, 0f));
                }
                else
                {
                    collision.transform.Translate(new Vector2(0.64f, 0f));
                }
            }
            else
            {
                if (direction.y > 0f)
                {
                    collision.transform.Translate(new Vector2(0f, -0.64f));
                }
                else
                {
                    collision.transform.Translate(new Vector2(0f, 0.64f));
                }
            }
        }
    }
}
