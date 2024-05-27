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

        public void Present(IItem item)
        {
            _renderer.sprite = item.UIIcon;
            gameObject.name = item.Name;
        }

        public void PickUP()
        {
            PickedUp?.Invoke();
        }

    }

    
}