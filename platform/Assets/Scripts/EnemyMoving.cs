using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    private float _speed = 4f;
    private Vector2 _moveDirection = Vector2.right;

    private void Update()
    {
        if(_moveDirection.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);

        if(transform.position.x <= _leftPoint.position.x)
        {
            _moveDirection = Vector2.right;
        }

        if(transform.position.x >= _rightPoint.position.x)
        {
            _moveDirection = Vector2.left;
        }
    }
}
