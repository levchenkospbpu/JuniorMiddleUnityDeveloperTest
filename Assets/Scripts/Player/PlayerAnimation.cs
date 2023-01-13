using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    private PlayerController _playerController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.magnitude / _playerController.MaxSpeed);
    }
}
