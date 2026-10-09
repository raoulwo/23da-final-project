using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Bewegung")]
    public float moveSpeed = 5.0f;

    [Header("Kamera & Interaktion")]
    public Transform playerCamera;
    public float mouseSensitivity = 2.0f;
    public float lookXLimit = 45.0f;
    [Tooltip("Taste, die gehalten werden muss, um sich umzusehen (z. B. Space)")]
    public Key lookKey = Key.Space;

    [Header("Input System")]
    [Tooltip("Die Input Actions Asset Referenz oder Action für Bewegung (Vector2)")]
    public InputActionReference moveActionReference;
    public InputActionReference lookActionReference;

    private CharacterController _controller;
    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private float _rotationX;

    [HideInInspector]
    public bool canMove = true;

    void OnEnable()
    {
        if (moveActionReference != null) moveActionReference.action.Enable();
        if (lookActionReference != null) lookActionReference.action.Enable();
    }

    void OnDisable()
    {
        if (moveActionReference != null) moveActionReference.action.Disable();
        if (lookActionReference != null) lookActionReference.action.Disable();
    }

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        // Cursor initial frei, da man die Leertaste drücken muss zum Umsehen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Prüfen, ob die Look-Taste (z. B. Leertaste) gehalten wird
        bool isLookingPressed = Keyboard.current != null && Keyboard.current[lookKey].isPressed;

        // Cursor-Verhalten entsprechend anpassen
        if (isLookingPressed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // 1. Inputs auslesen
        if (canMove)
        {
            if (moveActionReference != null)
                _moveInput = moveActionReference.action.ReadValue<Vector2>();
            else
                _moveInput = Vector2.zero;

            // Look nur verarbeiten, wenn die Taste gedrückt wird
            if (isLookingPressed && lookActionReference != null)
            {
                _lookInput = lookActionReference.action.ReadValue<Vector2>();

                // 2. Kamerasteuerung (Maus / Look-Action)
                _rotationX += -_lookInput.y * mouseSensitivity * 0.1f;
                _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
                playerCamera.localRotation = Quaternion.Euler(_rotationX, 0, 0);
                transform.Rotate(Vector3.up * (_lookInput.x * mouseSensitivity * 0.1f));
            }
            else
            {
                _lookInput = Vector2.zero;
            }
        }
        else
        {
            _moveInput = Vector2.zero;
        }

        // 3. Bewegung berechnen (WASD funktioniert unabhängig von der Leertaste)
        Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;

        // 4. Charakter bewegen
        _controller.Move(move * (moveSpeed * Time.deltaTime));
    }
}
