using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    [SerializeField] private Transform _targetCamera;
    [SerializeField, Range(0, 1)] private float _paralaxRange = 0f;

    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        _targetPreviousPosition = _targetCamera.position;
    }

    private void Update()
    {
        var delta = _targetCamera.position - _targetPreviousPosition;
        _targetPreviousPosition = _targetCamera.position;
        transform.position = new Vector3(_targetCamera.position.x * _paralaxRange, _targetCamera.position.y, transform.position.z);
    }
}
