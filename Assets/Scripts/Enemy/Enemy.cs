using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
     private Transform _playerTarget;
    
    [Inject]
    public void Construct(Transform playerTarget)
    {
        _playerTarget = playerTarget;
    }
    

    private void Update()
    {
        AttackToPlayer();
    }

    private void AttackToPlayer()
    {
        Vector3 direction = (_playerTarget.position - transform.position).normalized;
        
        // Перемещаем врага в направлении к игроку
        transform.position += direction * _moveSpeed * Time.deltaTime;

        // Поворачиваем врага в направлении к игроку
        transform.LookAt(_playerTarget);
    }
    
    public class Factory : PlaceholderFactory<Enemy>
    {
    }
}
