using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
   public string itemName; // Имя предмета
   public Sprite itemIcon; // Иконка предмета

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         // Найти компонент Inventory у игрока и добавить предмет
         Inventory playerInventory = other.GetComponent<Inventory>();
         if (playerInventory != null)
         {
            playerInventory.AddItem(this);
            Destroy(gameObject); // Удалить предмет из сцены после подбора
         }
      }
   }
}
