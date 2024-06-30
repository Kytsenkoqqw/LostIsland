using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerTransform;

    public override void InstallBindings()
    {
        // Устанавливаем Transform игрока
        Container
            .Bind<Transform>()
            .FromInstance(_playerTransform)
            .WhenInjectedInto<Enemy>();

        // Устанавливаем фабрику для врагов
        Container
            .BindFactory<Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(_enemyPrefab);
    }
}
