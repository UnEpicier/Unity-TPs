using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovements : MonoBehaviour
{
    private float speed = 0.13f;
    public bool isJumping = false;
    private float jumpHeight = 300f;

    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        /** --- Jump -------------------------------------------------------*/
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpHeight);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        /** --- Move player along 2D axis ----------------------------------*/
        float moveH = Input.GetAxis("Horizontal") * speed;
        transform.Translate(new Vector2(moveH, 0));

        /** --- Rotate sprite ----------------------------------------------*/
        if (moveH < 0)
        {
            sr.flipX = true;
        } else if (moveH > 0)
        {
            sr.flipX = false;
        }

        /** --- Update animator --------------------------------------------*/
        animator.SetFloat("Speed", Mathf.Abs(moveH));
        animator.SetBool("IsJumping", isJumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumping && collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            transform.parent = null;
        }
    }
}
