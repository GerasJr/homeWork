using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackPanel : MonoBehaviour
{
    [SerializeField] private Color _eclipseColor;
    [SerializeField] private Image _panelImage;

    private float _eclipseDuration = 3;

    public void Eclipse()
    {
        _panelImage.DOColor(_eclipseColor, _eclipseDuration);
    }
}
