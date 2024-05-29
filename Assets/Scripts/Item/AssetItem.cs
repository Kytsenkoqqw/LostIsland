﻿using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "Item")]
    public class AssetItem : ScriptableObject, IItem
    {
        public string Name => _name;
        public Sprite UIIcon => _uiIcon;
        public GameObject ObjectPrefab => _objectPrefab;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _uiIcon;
        [SerializeField] private GameObject _objectPrefab;

    }
}