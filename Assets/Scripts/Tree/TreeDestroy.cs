using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _lootPrefab;
    [SerializeField] private Transform _dropPoint;
    
    public void OnButtonClick()
    {
        StartCoroutine(DestroyTree());
    }

    public IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(_lootPrefab, _dropPoint.position, Quaternion.Euler(0,0,0));
        Destroy(gameObject);
        
    }
}
