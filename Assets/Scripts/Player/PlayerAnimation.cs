using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PlayerMoveAnimation(float speed)
    {
        _animator.SetFloat("Speed", Mathf.Abs(speed));
    }
}
