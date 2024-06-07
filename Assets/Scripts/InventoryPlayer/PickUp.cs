using Item;
using UnityEngine;

namespace InventoryPlayer
{
    public class PickUp : MonoBehaviour
    {
        public AssetItem item; 

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Inventory inventory = FindObjectOfType<Inventory>(true);
                if (inventory != null)
                {
                    inventory.AddItem(item);
                    Destroy(gameObject);
                }
            }
        }
    }
}