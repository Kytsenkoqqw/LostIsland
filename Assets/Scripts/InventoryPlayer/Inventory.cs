using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    private List<PickupItem> items = new List<PickupItem>();

    public Transform inventoryUIParent; // Родительский объект для элементов UI инвентаря
    public GameObject inventorySlotPrefab; // Префаб слота инвентаря

    public void AddItem(PickupItem item)
    {
        items.Add(item);
        Debug.Log("Added item: " + item.itemName);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        // Очистка старых элементов UI
        foreach (Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }

        // Добавление новых элементов UI
        foreach (var item in items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryUIParent);
            Image icon = slot.transform.Find("ItemIcon").GetComponent<Image>();
            icon.sprite = item.itemIcon;
        }
    }


}
