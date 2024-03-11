using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour, IShowButtonTrigger
{
    [SerializeField] private GameObject _treeButtonPrefab;
    [SerializeField] private Transform _spawnButtonPoint;
    [SerializeField] private Image _imageButton;
    private GameObject _spawnedButton;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            ShowButton();
            Debug.Log("Enter");
        }
    }
    
    public void OnTriggerExit(Collider collider)
    {
        HideButton();
        Debug.Log("Exit");
    }

    public void ShowButton()
    {
        _spawnedButton = Instantiate(_treeButtonPrefab, _spawnButtonPoint);
        _spawnedButton.SetActive(true);
        
        
    }

    public void HideButton()
    {
        if (_spawnedButton != null)
        {
            _spawnedButton.SetActive(false);
        }
    }
}
