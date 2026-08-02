using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("輸入")]
    Vector2 moveInput;
    [SerializeField] Vector3 Move;


    [Header("組件")]
    [SerializeField] CharacterController character;
    [SerializeField] PlayerInput Input;

    public float speed;

    [Header("動作")]
    InputAction moveAction;

    void Awake()
    {
        Input = GetComponent<PlayerInput>();
        character = GetComponent<CharacterController>();
        moveAction = Input.actions["Move"];
    }

    void Start()
    {

    }
    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
    }
    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
    }

    void Update()
    {
        Move = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 realMove = Move * speed * Time.deltaTime;
        character.Move(realMove);
        Debug.Log(realMove);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

}