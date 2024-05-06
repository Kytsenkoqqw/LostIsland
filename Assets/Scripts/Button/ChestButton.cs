using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class ChestButton : MonoBehaviour
{
    [SerializeField] private Transform _targetChest;
    [SerializeField] private Vector3 _offset = new Vector3(0, 1, 0);


    private void Start()
    {
        GameObject buttonParent = new GameObject("ButtonParent");
        buttonParent.transform.position = _targetChest.position;
        
        transform.SetParent(buttonParent.transform);
    }

    private void Update()
    {
        transform.parent.position = _targetChest.position + _offset;
    }
}
