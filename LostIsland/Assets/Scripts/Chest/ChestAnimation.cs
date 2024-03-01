using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChestAnimation : MonoBehaviour
{
    [SerializeField] private string ClosedChest = "Closed";
    [FormerlySerializedAs("_closedChestButton")] [SerializeField] private GameObject _openChestButton;
   // private readonly int ClosedChest = Animator.StringToHash("Closed");
    private bool _isStay = false;
    private bool _openChest = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            _isStay = true;
            _openChestButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            _isStay = false;
            _animator.SetTrigger(ClosedChest);
            GameManager.instance.ClosedInventoryChest();
            _openChestButton.SetActive(false);
            
        }
    }
}
