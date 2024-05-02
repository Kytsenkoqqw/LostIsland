using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _playerPosition;

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _playerPosition.position = _targetPosition.position;
        }
    }
}
