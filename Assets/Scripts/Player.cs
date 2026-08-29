using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action<Vector2> OnLookInput;
    public event Action OnFireInput;

    [Header("輸入")]
    [SerializeField] PlayerInput Input;

    InputAction moveAction;
    InputAction Look;
    InputAction Fire;

    void Awake()
    {
        Input = GetComponent<PlayerInput>();

        moveAction = Input.actions["Move"];
        Look = Input.actions["Look"];
        Fire = Input.actions["Fire"];
    }

    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        Look.performed += OnLook;
        Look.canceled += OnLook;

        Fire.performed += OnFire;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        Look.performed -= OnLook;
        Look.canceled -= OnLook;

        Fire.performed -= OnFire;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        OnLookInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        OnFireInput?.Invoke();
    }
}