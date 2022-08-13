using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    private Vector3 _targetVector;
    private float _pathSpeed = 0.1f;

    private void FixedUpdate()
    {
        _targetVector = new Vector3(_targetTransform.position.x, _targetTransform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, _targetVector, _pathSpeed);
    }
}
