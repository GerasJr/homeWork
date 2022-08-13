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

    private void Start()
    {
        _text.text = "";
    }

    public void WinMessage()
    {
        _text.DOText("You win!", 3).SetRelative();
        _text.DOColor(_colorWin, 3);
    }

    public void LoseMessage()
    {
        _text.DOText("You lose", 3).SetRelative();
        _text.DOColor(_colorLose, 3);
    }
}
