using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Animator _animator;

    private readonly float _walkSpeed = 2f;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveH = Input.GetAxis("Horizontal") * _walkSpeed * Time.deltaTime;
        float moveV = Input.GetAxis("Vertical") * _walkSpeed * Time.deltaTime;

        if (moveH < 0)
        {
            _sr.flipX = true;
        }
        else if (moveH > 0)
        {
            _sr.flipX = false;
        }

        transform.Translate(new Vector2(moveH, moveV));
        _animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(moveH), Mathf.Abs(moveV)));
    }
}
