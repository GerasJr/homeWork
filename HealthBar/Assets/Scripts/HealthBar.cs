using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;
    private float _changeRate = 150f;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.ReturnHealth(), _changeRate * Time.deltaTime);
    }
}
