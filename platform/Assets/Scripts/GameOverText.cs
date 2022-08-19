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

    private float _animationSpeed = 3f;

    private void Start()
    {
        _text.text = "";
    }

    public void WinMessage()
    {
        _text.DOText("You win!", _animationSpeed).SetRelative();
        _text.DOColor(_colorWin, _animationSpeed);
    }

    public void LoseMessage()
    {
        _text.DOText("You lose", _animationSpeed).SetRelative();
        _text.DOColor(_colorLose, _animationSpeed);
    }
}
