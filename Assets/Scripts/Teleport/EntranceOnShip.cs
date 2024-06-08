using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntranceOnShip : MonoBehaviour
{
    public static EntranceOnShip instance;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private GameObject _entranceOnShip;
    [SerializeField] private GameObject _spawnPointOnShip;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _playerPosition.position = _targetPosition.position;
        }
    }

    public void ShowEntrancePoint()
    {
        if (_entranceOnShip != null)
        {
            _entranceOnShip.SetActive(true);
        }
    }
}
