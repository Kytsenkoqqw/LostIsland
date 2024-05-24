using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Image _iconField;
    
    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }
}
