using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChoppingWoodSound : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _choppingAudio;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _choppingAudio;
    }

    public void PlayChoppingSound()
    {
        if (_audioSource != null && _choppingAudio != null)
        {
            _audioSource.Play();
        }
    }
}
