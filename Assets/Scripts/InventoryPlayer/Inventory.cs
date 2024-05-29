using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private List<AssetItem> Items;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private ItemsEjector _ejector;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnEnable()
    {
        Render(Items);
    }

    public void AddItem(AssetItem item)
    {
        Items.Add(item);
        Render(Items);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
        
        items.ForEach(item => 
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Init(_draggingParent);
            cell.Render(item);
            cell.Ejecting += () => Destroy(cell.gameObject);
            cell.Ejecting += () => _ejector.EjectFromPool(item, _ejector.transform.position, _ejector.transform.right);
        }
        );
    }
}
