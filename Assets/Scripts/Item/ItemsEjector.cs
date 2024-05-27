﻿using System;
using Item;
using UnityEditor;
using UnityEngine;



    public class ItemsEjector : MonoBehaviour
    {
        [SerializeField] private ItemsObjectPool _pool;
        [SerializeField] private float _range;
        [SerializeField] private TerrainCollider _groung;
        [SerializeField] private AssetItem itemData;

        public void EjectFromPool(IItem item, Vector3 position, Vector3 direction)
        {
            var presenter = _pool.Get(item);
            presenter.transform.position = position;

            var target = position + (direction.normalized * _range);
            target = _groung.bounds.ClosestPoint(target);

            presenter.gameObject
                .AddComponent<MovingAlongCurve>()
                .StartMoving(position, target, Vector3.Lerp(position, target, 0.5f) + new Vector3(0, 2, 0), 1)
                .RemoveWhenFinished();
        }

        private void OnTriggerEnter(Collider other)
        {
            // Проверяем, столкнулся ли игрок с объектом, имеющим тэг "Item"
            if (other.CompareTag("Item"))
            {
                // Получаем компонент предмета
                Progress.Item item = other.GetComponent<Progress.Item>();
            
                // Проверяем, что компонент предмета существует
                if (item != null)
                {
                    // Добавляем предмет в инвентарь игрока
                    Inventory.instance.AddItem(item.itemName);
                
                    // Уничтожаем объект предмета
                    Destroy(other.gameObject);
                }
            }
        }
    }   
