using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour, IShowButtonTrigger
{
    [SerializeField] private GameObject _treeButtonPrefab;
    [SerializeField] private Transform _spawnButtonPoint;
    [SerializeField] private Image _imageButton;

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
        var Button = Instantiate(_treeButtonPrefab, _spawnButtonPoint.position, Quaternion.identity);
        Button.transform.SetParent(_spawnButtonPoint);
        _treeButtonPrefab.SetActive(true);
    }

    public void HideButton()
    {
        _treeButtonPrefab.SetActive(false);
    }
}
