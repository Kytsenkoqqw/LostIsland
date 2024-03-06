using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour, IShowButtonTrigger
{
    [SerializeField] private GameObject _treeButtonPrefab;
    [SerializeField] private Transform _spawnButtonPoint;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            Debug.Log("Enter");
        }
    }
    
    public void OnTriggerExit(Collider collider)
    {
        ShowButton();
    }

    public void ShowButton()
    {
        GameObject buttonInstance = Instantiate(_treeButtonPrefab, _spawnButtonPoint.position, Quaternion.identity);
        // Добавляем к кнопке родительский объект (чтобы она спавнилась в нужной позиции)
        buttonInstance.transform.SetParent(_spawnButtonPoint, false);
    }
}
