using System;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    public Action inRange;
    public Action outOfRange;
    public Action pressed;

    private Controls _controls;
    private bool _inRange;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
        _controls.Player.Interact.performed += context =>
        {
            TryPress();
        };
    }

    private void OnDisable()
    {
        _controls.Player.Interact.performed -= context =>
        {
            TryPress();
        };
        _controls.Player.Disable();
    }

    private void TryPress()
    {
        if (_inRange)
        {
            pressed?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _inRange = true;
            inRange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _inRange = false;
            outOfRange?.Invoke();
        }
    }
}
