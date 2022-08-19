using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Color _colorWin;
    [SerializeField] private Color _colorLose;

    private float _animationDuration = 3f;

    private void Start()
    {
        _text.text = "";
    }

    public void WinMessage()
    {
        _text.DOText("You win!", _animationDuration).SetRelative();
        _text.DOColor(_colorWin, _animationDuration);
    }

    public void LoseMessage()
    {
        _text.DOText("You lose", _animationDuration).SetRelative();
        _text.DOColor(_colorLose, _animationDuration);
    }
}
