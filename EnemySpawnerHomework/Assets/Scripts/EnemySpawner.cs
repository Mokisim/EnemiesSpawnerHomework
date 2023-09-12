using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemyPrefab;

    private Transform[] _points;

    private float _spawnInterval = 2f;
    private float _nextSpawnTime;

    private WaitForSeconds coldown;

    private void Awake()
    {
        _points = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }

        coldown = new WaitForSeconds(_spawnInterval);

        StartCoroutine(SpawnEnemies());
    }

    
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Spawn();
            yield return coldown;
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _points.Length);
        Transform randomSpawnPoint = _points[randomIndex];

        Enemy enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        Vector2 spawnDirection = randomSpawnPoint.position - _spawnPoint.position;
        EnemyMovement enemyMove = enemy.GetComponent<EnemyMovement>();
        enemyMove.SetMovementDirection(spawnDirection);
    }

}
