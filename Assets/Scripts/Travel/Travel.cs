using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Travel : MonoBehaviour
{
    public static Travel instance;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private GameObject _worldMapPoint;
    [SerializeField] private Transform _firstIsland;
    [SerializeField] private Transform _secondIsland;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private GameObject _worldMapButton;
    [SerializeField] private GameObject _worldMap;
    

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
            _worldMapButton.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _worldMapButton.SetActive(false);
        }
    }

    public void TravelOnFirstIsland()
    {
        _loadScreen.SetActive(true);
        StartCoroutine(TravelProcess());
        _playerPosition.position = _firstIsland.position;
    }

    public void TravelOnSecondIsland()
    {
        _loadScreen.SetActive(true);
        StartCoroutine(TravelProcess());
        _playerPosition.position = _secondIsland.position;
    }

    public void ShowWorldMap()
    {
        _worldMap.SetActive(true);
    }

    public void ClosedWorldMap()
    {
        _worldMap.SetActive(false);
    }

    public void ShowEntrancePoint()
    {
        if (_worldMapPoint != null)
        {
            _worldMapPoint.SetActive(true);
        }
    }
    
     IEnumerator TravelProcess()
    {
        yield return new WaitForSeconds(1f);
        _loadScreen.SetActive(false);
    }
     
}
