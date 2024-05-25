using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    } 
    
    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform) _originalParent))
        {
            InsertInGrig();
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
    }

    private void InsertInGrig()
    {
        int closestIndex = 0;
        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) < Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }

        transform.parent = _originalParent;
        transform.SetSiblingIndex(closestIndex);
    }
}
