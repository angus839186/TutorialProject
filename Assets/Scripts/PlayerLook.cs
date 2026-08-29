using JetBrains.Annotations;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    public float xRotation = 0f;

    public float mouseSentivity = 0f;

    [SerializeField] Player player;

    public Vector2 lookInput;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        player.OnLookInput += SetLookInput;
    }

    void OnDisable()
    {
        player.OnLookInput -= SetLookInput;
    }

    void Update()
    {
        Look(lookInput);
    }
    public void Look(Vector2 lookInput)
    {
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        xRotation -= mouseY * Time.deltaTime * mouseSentivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); //限制轉動數值的最大、最小值

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * mouseSentivity);
    }

    void SetLookInput(Vector2 input)
    {
        lookInput = input;
    }

}