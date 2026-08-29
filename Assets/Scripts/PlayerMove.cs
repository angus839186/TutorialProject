using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    [SerializeField] Player player;
    [SerializeField] CharacterController character;

    public Vector2 moveInput;

    void Awake()
    {
        player = GetComponent<Player>();
        character = GetComponent<CharacterController>();
    }
    void OnEnable()
    {
        player.OnMoveInput += SetMoveInput;
    }

    void OnDisable()
    {
        player.OnMoveInput -= SetMoveInput;
    }
    void Update() //函式、方法、功能
    {
        // Move = new Vector3(moveInput.x, 0, moveInput.y);
        // Vector3 realMove = Move * speed * Time.deltaTime; //區域變數
        // character.Move(realMove);

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize(); //將傳入的向量數值轉為固定1
        right.Normalize();

        Vector3 moveVector = right * moveInput.x + forward * moveInput.y;
        character.Move(moveVector * speed * Time.deltaTime);
    }

    void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }
}