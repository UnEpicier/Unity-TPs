using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float speed = 0.1f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /** --- Move player along 2D axis ----------------------------------*/
        float moveH = Input.GetAxis("Horizontal") * speed;
        float moveV = Input.GetAxis("Vertical") * speed;

        rb.AddForce(new Vector2(moveH, moveV), ForceMode2D.Impulse);

        /** --- Keep player inside the screen ------------------------------*/

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
    }
}
