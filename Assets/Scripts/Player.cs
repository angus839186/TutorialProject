using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action<Vector2> OnMoveInput;
    public event Action<Vector2> OnLookInput;
    public event Action OnReloadInput;
    public event Action OnFireInput;

    [Header("輸入")]
    [SerializeField] PlayerInput Input;



    [Header("動作")]
    InputAction move;
    InputAction look;
    InputAction fire;
    InputAction reload;


    void Awake()
    {
        Input = GetComponent<PlayerInput>();
        move = Input.actions["Move"];
        look = Input.actions["Look"];
        fire = Input.actions["Fire"];
        reload = Input.actions["Reload"];
    }

    void OnEnable()
    {
        move.performed += OnMove;
        move.canceled += OnMove;
        look.performed += OnLook;
        look.canceled += OnLook;
        fire.performed += OnFire;
        reload.performed += OnReload;
    }
    void OnDisable()
    {
        move.performed -= OnMove;
        move.canceled -= OnMove;
        look.performed -= OnLook;
        look.canceled -= OnLook;
        fire.performed -= OnFire;
        reload.performed -= OnReload;
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
    public void OnReload(InputAction.CallbackContext context)
    {
        OnReloadInput?.Invoke();
    }

}