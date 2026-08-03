using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region 欄位變數、公開變數
    [Header("輸入")]
    public Vector2 moveInput;
    public Vector2 rotateInput;
    [SerializeField] Vector3 Move;

    public PlayerLook playerLook;
    public PlayerMove playerMove;


    [Header("組件")]
    [SerializeField] CharacterController character;
    [SerializeField] PlayerInput Input;

    public float speed;

    #endregion

    [Header("動作")]
    InputAction moveAction;
    InputAction Look;


    void Awake()
    {
        Input = GetComponent<PlayerInput>();
        character = GetComponent<CharacterController>();
        moveAction = Input.actions["Move"];
        Look = Input.actions["Look"];
    }

    void Start()
    {
    }
    void OnEnable() 
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        Look.performed += OnLook;
        Look.canceled += OnLook;
    }
    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
         Look.performed -= OnLook;
        Look.canceled -= OnLook;
    }

    //遊戲開始後會一直更新
    void Update() //函式、方法、功能
    {
        Move = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 realMove = Move * speed * Time.deltaTime; //區域變數
        character.Move(realMove);
    }

    void FixedUpdate()
    {
        playerLook.Look(rotateInput);
    }

    //接收移動輸入
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<Vector2>();
        Debug.Log(rotateInput);
    }
    
}