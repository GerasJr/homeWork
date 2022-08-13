using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private float _animationTime = 1f;
    private float _jumpPower = 3f;
    private int _jumpAmount = 1;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void PickAnimation()
    {
        _boxCollider.enabled = false;
        transform.DOJump(transform.position, _jumpPower, _jumpAmount, _animationTime);
        _spriteRenderer.DOFade(0, _animationTime);
        Destroy(gameObject, _animationTime);
    }
}
