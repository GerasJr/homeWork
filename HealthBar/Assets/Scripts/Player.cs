using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthChanged;

    public float Health { get; private set; } = 100;
    private float _maxHealth = 100;
    private float _minHealth = 0;
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

    public void Heal(float value)
    {
        if (_isDead == false)
        {
            Health = Mathf.Clamp(Health + value, _minHealth, _maxHealth);
            _healthChanged?.Invoke();
        }
    }

    public void Damage(float value)
    {
        if(_isDead == false)
        {
            Health = Mathf.Clamp(Health - value, _minHealth, _maxHealth);
            _healthChanged?.Invoke();

            if (Health == _minHealth)
            {
                Die();
            }
        }
    }
}
