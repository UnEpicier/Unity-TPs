using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Animator _animator;

    private float _walkSpeed = 1f;
    private float _runSpeed = 2f;

    private bool _isRunning = false;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = true;
        } else
        {
            _isRunning = false;
        }

        float moveH = Input.GetAxis("Horizontal") * (_isRunning ? _runSpeed : _walkSpeed);
        float moveV = Input.GetAxis("Vertical") * (_isRunning ? _runSpeed : _walkSpeed);

        if (moveH < 0)
        {
            _sr.flipX = true;
        }
        else if (moveH > 0)
        {
            _sr.flipX = false;
        }

        transform.Translate(new Vector2(moveH * Time.deltaTime, moveV * Time.deltaTime));
        _animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(moveH), Mathf.Abs(moveV)));
        _animator.SetBool("Is Running", _isRunning);
    }
}
