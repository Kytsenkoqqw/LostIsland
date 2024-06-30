using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _radiusSpawn = 5f;
    [SerializeField] private int _quantityEnemy = 5;
    [SerializeField] private float _heightSpawn = 5f;

    private Enemy.Factory _enemyFactory;

    [Inject]
    public void Construct(Enemy.Factory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _quantityEnemy; i++)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Enemy enemy = _enemyFactory.Create();
            enemy.transform.position = spawnPoint.position;
        }
    }
}
