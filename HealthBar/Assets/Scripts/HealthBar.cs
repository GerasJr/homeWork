using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Coroutine changeValueJob;
    private Slider _healthBar;
    private float _changeRate = 150f;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private IEnumerator ChangeValue()
    {
        while(_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health, _changeRate * Time.deltaTime);
            yield return null;
        }
    }

    public void StartChangeValue()
    {
        if (changeValueJob != null)
        {
            StopCoroutine(changeValueJob);
        }

        changeValueJob = StartCoroutine(ChangeValue());
    }
}
