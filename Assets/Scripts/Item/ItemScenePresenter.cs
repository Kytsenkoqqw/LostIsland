using System;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Item
{
    public class ItemScenePresenter : MonoBehaviour
    {
        public event Action PickedUp;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private GameObject _itemObject;

        public void Present(IItem item)
        {
            _renderer.sprite = item.UIIcon;
            gameObject.name = item.Name;
            
            if (item is AssetItem assetItem && assetItem.Prefab != null)
            {
                if (_itemObject != null)
                {
                    Destroy(_itemObject);
                }
                _itemObject = Instantiate(assetItem.Prefab, transform);
                _itemObject.transform.localPosition = Vector3.zero;
            }
        }

        public void PickUP()
        {
            PickedUp?.Invoke();
        }
    }

    
}