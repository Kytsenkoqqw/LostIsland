using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowButtonTravel : MonoBehaviour
{
    [SerializeField] private GameObject _shipTravelButton;

    private void OnTriggerEnter(Collider other)
    {
        _shipTravelButton.SetActive(true);
    }
}
