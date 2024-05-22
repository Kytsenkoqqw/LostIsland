using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.magnitude);
    }
}
