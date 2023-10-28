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
                // Left
                if (direction.x > 0f)
                {
                    if (collision.gameObject.GetComponent<Box>().CanMoveInDirection("Left"))
                    {
                        collision.transform.Translate(new Vector2(-0.64f, 0f));
                    }
                }
                // Right
                else
                {
                    if (collision.gameObject.GetComponent<Box>().CanMoveInDirection("Right"))
                    {
                        collision.transform.Translate(new Vector2(0.64f, 0f));
                    }
                }
            }
            else
            {
                // Down
                if (direction.y > 0f)
                {
                    if (collision.gameObject.GetComponent<Box>().CanMoveInDirection("Down"))
                    {
                        collision.transform.Translate(new Vector2(0f, -0.64f));
                    }
                }
                // Up
                else
                {
                    if (collision.gameObject.GetComponent<Box>().CanMoveInDirection("Up"))
                    {
                        collision.transform.Translate(new Vector2(0f, 0.64f));
                    }
                }
            }
        }
    }
}
