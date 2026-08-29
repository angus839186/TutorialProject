using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2f;

    [SerializeField] Player player;
    [SerializeField] CharacterController character;

    Vector2 moveInput;

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

    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = right * moveInput.x + forward * moveInput.y;

        character.Move(move * speed * Time.deltaTime);
    }

    void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }
}