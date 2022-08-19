using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpForce = 500f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _jumpVector;
    private float _directionMove;
    private bool _isGrounded = false;
    private const string _isRunAnimation = "IsRun";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _jumpVector = new Vector2(0f, _jumpForce);
    }

    private void Update()
    {
        _directionMove = Input.GetAxis("Horizontal");

        if (_directionMove < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_directionMove > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(_jumpVector);
        }

        if (_directionMove != 0 && _isGrounded == true)
        {
            _animator.SetBool(_isRunAnimation, true);
        }
        else
        {
            _animator.SetBool(_isRunAnimation, false);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(_directionMove * _speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = false;
        }
    }
}
