using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Flood : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        float _step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);
    }
}
