using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


//Player接收輸入--->Player輸出事件(Action)---->有訂閱Player事件的腳本接收事件通知---->接收通知後，做他們要做的事情
public class Player : MonoBehaviour
{

    public event Action<Vector2> OnMoveInput;
    public event Action<Vector2> OnLookInput;
    public event Action OnFireInput;
    public event Action OnReloadInput;

    [Header("輸入")]
    [SerializeField] PlayerInput Input;

    [Header("動作")]
    InputAction move;
    InputAction look;
    InputAction fire;
    InputAction Reload;


    void Awake()
    {
        Input = GetComponent<PlayerInput>();
        move = Input.actions["Move"];
        look = Input.actions["Look"];
        fire = Input.actions["Fire"];
        Reload = Input.actions["Reload"];
    }

    void Start()
    {
    }
    void OnEnable()
    {
        move.performed += OnMove;
        move.canceled += OnMove;
        look.performed += OnLook;
        look.canceled += OnLook;
        fire.performed += OnFire;
        Reload.performed += OnReload;
    }
    void OnDisable()
    {
        move.performed -= OnMove;
        move.canceled -= OnMove;
        look.performed -= OnLook;
        look.canceled -= OnLook;
        fire.performed -= OnFire;
        Reload.performed -= OnReload;
    }

    //接收移動輸入
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