using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset = new Vector3(10f, 10f, -10f);

    private void LateUpdate()
    {
        Vector3 newPosition = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
    }
}
