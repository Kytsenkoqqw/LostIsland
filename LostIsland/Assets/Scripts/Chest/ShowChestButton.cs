using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChestButton : MonoBehaviour
{
   [SerializeField] private GameObject _chestButton;
   private bool _isStay = false;

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<PlayerController>())
      {
         _isStay = true;
         _chestButton.SetActive(true);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.GetComponent<PlayerController>())
      {
         _isStay = false;
         _chestButton.SetActive(false);
      }
   }
}
