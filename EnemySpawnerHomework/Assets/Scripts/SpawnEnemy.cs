using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _points;

    private float _spawnInterval = 2f;
    private float _nextSpawnTime;

    private void Awake()
    {
        _points = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }

        StartCoroutine(SpawnEnemies());
    }

    
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _points.Length);
        Transform randomSpawnPoint = _points[randomIndex];

        Enemy enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        Vector2 spawnDirection = randomSpawnPoint.position - _spawnPoint.position;
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.SetMovementDirection(spawnDirection);
    }

}
