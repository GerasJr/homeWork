using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Transform _coinsParent;
    [SerializeField] private Text _coinsAmountUI;

    private Player _player;
    private int _coinsAmount = 0;
    private int _coinsOnLevel;

    private void Start()
    {
        _player = GetComponent<Player>();
        _coinsOnLevel = _coinsParent.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();
            coin.PickAnimation();
            _coinsAmountUI.text = $"{_coinsAmount + 1}/{_coinsOnLevel}";
            _coinsAmount++;

            if(_coinsAmount == _coinsOnLevel)
            {
                _player.CoinsCollected();
            }
        }
    }
}
