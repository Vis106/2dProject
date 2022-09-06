using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;

    private Coroutine _spawnEnemyWithDelay;

    private void Start()
    {
        Initialize(_enemyPrefab.gameObject);
        TurnOnSpawner();
    }
        
    private IEnumerator SpawnEnemy()
    {
        var timeInterval = new WaitForSeconds(_delay);

        while (TryGetObject(out GameObject enemy))
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            yield return timeInterval;

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void TurnOnSpawner()
    {
        if (_spawnEnemyWithDelay != null)
        {
            StopCoroutine(_spawnEnemyWithDelay);
        }

        _spawnEnemyWithDelay = StartCoroutine(SpawnEnemy());
    }
}

