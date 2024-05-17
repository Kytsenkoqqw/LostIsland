using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OpenChest : MonoBehaviour
{
    [FormerlySerializedAs("_closedChestButton")] [SerializeField] private GameObject _openChestButton;
    [SerializeField] private string ClosedChest = "Closed";
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _openChestSound;
    private bool _isStay;
    private bool _openChest = false;
    private Animator _animator;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _openChestSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            _isStay = true;
            _openChestButton.SetActive(true);
            _openChestButton.GetComponentInParent<OpenChest>();
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

    public void PlayOpenChestSound()
    {
        if (_audioSource != null && _openChestSound != null)
        {
            _audioSource.Play();
        }
    }

    public void ClosedChestButton()
    {
        _animator.SetTrigger(ClosedChest);
    }
}
