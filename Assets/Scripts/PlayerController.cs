using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float MaxSpeed { get; private set; }

    private Controls _controls;
    private InputAction _move;

    private Rigidbody _rb;
    private Vector3 _forceDirection = Vector3.zero;

    [SerializeField]
    private Camera _playerCamera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _move = _controls.Player.Movement;
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        Move();
        LookAt();
    }

    private void Move()
    {
        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_playerCamera) * MaxSpeed;
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_playerCamera) * MaxSpeed;

        _rb.velocity = _forceDirection;
        _forceDirection = Vector3.zero;
    }

    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0 && direction.sqrMagnitude > 0)
        {
            _rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
