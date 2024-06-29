using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterEnemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float _speedEnemy;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private float _radiusSpawn = 5f;
    [SerializeField] private int _quantityEnemy = 5;
    [SerializeField] private float _heightSpawn = 5f;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _quantityEnemy; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * _radiusSpawn;
            randomPos.y = _heightSpawn;
            Instantiate(_prefabEnemy, transform.position + randomPos, Quaternion.identity);
        }
    }
}
