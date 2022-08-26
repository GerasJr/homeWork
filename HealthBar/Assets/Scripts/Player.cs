using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100;
    private float _maxHealth = 100;
    private float _healthChangeValue = 10;
    private BoxCollider2D _boxCollider2D;
    private bool _isDead = false;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Die()
    {
        _boxCollider2D.enabled = false;
        _isDead = true;
    }

    public void Heal()
    {
        if (_health <= _maxHealth - _healthChangeValue)
        {
            _health += _healthChangeValue;
        }
    }

    public void Damage()
    {
        _health -= _healthChangeValue;

        if(_health <= 0)
        {
            Die();
        }
    }

    public float ReturnHealth()
    {
        return _health;
    }

    public bool ReturnIsDead()
    {
        return _isDead;
    }
}
