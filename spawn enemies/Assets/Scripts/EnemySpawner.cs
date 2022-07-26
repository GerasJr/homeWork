using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPoints;

    private int _secondsInterval = 2;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Transform tempPoint = _spawnPoints[i];
            _spawnPoints[i] = _spawnPoints[randomIndex];
            _spawnPoints[randomIndex] = tempPoint;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemy, _spawnPoints[i].position, Quaternion.identity);
            yield return new WaitForSeconds(_secondsInterval);
        }
    }
}
