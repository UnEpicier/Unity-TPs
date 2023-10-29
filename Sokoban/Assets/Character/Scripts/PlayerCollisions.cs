using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    if (collision.gameObject.GetComponent<Box>().TryMoveInDirection("Left"))
                    {
                        collision.transform.Translate(new Vector2(-0.64f, 0f));
                    }
                }
                // Right
                else
                {
                    if (collision.gameObject.GetComponent<Box>().TryMoveInDirection("Right"))
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
                    if (collision.gameObject.GetComponent<Box>().TryMoveInDirection("Down"))
                    {
                        collision.transform.Translate(new Vector2(0f, -0.64f));
                    }
                }
                // Up
                else
                {
                    if (collision.gameObject.GetComponent<Box>().TryMoveInDirection("Up"))
                    {
                        collision.transform.Translate(new Vector2(0f, 0.64f));
                    }
                }
            }

            // Now check if all boxes are in their EndZone and if so, end the game on a win!
            GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
            GameObject[] endZones = GameObject.FindGameObjectsWithTag("EndZone");

            int boxesPlaced = 0;
            foreach (GameObject box in boxes)
            {
                foreach(GameObject endZone in endZones)
                {
                    if (box.transform.position == endZone.transform.position)
                    {
                        boxesPlaced++;
                        break;
                    }
                }
            }

            ATH.SetText(boxesPlaced);

            if (boxesPlaced == boxes.Length)
            {
                StartCoroutine(DisplayEndScreen());
            }
        }
    }

    private IEnumerator DisplayEndScreen()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("End Screen", LoadSceneMode.Single);
    }
}
