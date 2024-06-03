using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Item;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   public event Action Ejecting;
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private Image _iconField;

    private Transform _draggingParent;
    private Transform _originalParent;
    private AssetItem _item;

    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    } 
    
    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
        _item = (AssetItem)item; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_draggingParent, false); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform)_originalParent))
        {
            InsertInGrid();
        }
        else
        {
            Eject();
        }
    }

    private bool In(RectTransform originalParent)
    {
        Vector2 localMousePosition = originalParent.InverseTransformPoint(Input.mousePosition);
        bool isInside = originalParent.rect.Contains(localMousePosition);
        Debug.Log("Is Inside: " + isInside);
        return isInside;
    }

    private void Eject()
    {
        Ejecting?.Invoke();
        ItemsEjector ejector = FindObjectOfType<ItemsEjector>();
        if (ejector != null)
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            ejector.EjectFromPool(_item, mouseWorldPosition, Vector3.right);
        }
    }

    private void InsertInGrid()
    {
        int closestIndex = 0;
        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) < Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }

        transform.SetParent(_originalParent, false); 
        transform.SetSiblingIndex(closestIndex);
    }

   
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); 
        float distance;

        if (groundPlane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return mousePosition; 
    }
}
