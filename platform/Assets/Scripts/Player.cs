using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerDie;
    [SerializeField] private UnityEvent _playerWin;
    [SerializeField] private CameraMoving _cameraMoving;
    [SerializeField] private Transform _depthLevel;

    private BoxCollider2D _boxCollider;
    private PlayerMoving _playerMoving;
    private bool _isDie = false;
    private bool _isWin = false;

    private void Start()
    {
        _playerMoving = GetComponent<PlayerMoving>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(transform.position.y <= _depthLevel.position.y)
        {
            Die();
        }
    }

    public void CoinsCollected()
    {
        if(_isDie == false && _isWin == false)
        {
            _playerWin?.Invoke();
            _isWin = true;
        }
    }

    public void Die()
    {
        if (_isWin == false && _isDie == false)
        {
            _playerDie?.Invoke();
            _playerMoving.enabled = false;
            _boxCollider.enabled = false;
            _cameraMoving.enabled = false;
            _isDie = true;
        }
    }
}
