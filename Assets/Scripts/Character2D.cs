using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character2D : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    [SerializeField] private float speed = 5.0f;

    private InputManager _inputManager;
    private Animator _animator;
    private Rigidbody2D _rb;

    private Vector2 _moveInput;
    private Vector2 _lastDirection = Vector2.down;

    private void Start()
    {
        _inputManager = InputManager.Instance;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = _inputManager.MoveInput;

        var isMoving = _moveInput.magnitude > 0.01f;

        if (isMoving)
        {
            _lastDirection = _moveInput;
        }

        _animator.SetBool(IsMoving, isMoving);

        var animDirection = isMoving ? _moveInput : _lastDirection;

        float finalMoveX;
        float finalMoveY;
        const float epsilon = 0.2f;

        if (Mathf.Abs(animDirection.y) >= Mathf.Abs(animDirection.x) + epsilon)
        {
            finalMoveX = 0.0f;
            finalMoveY = Mathf.Sign(animDirection.y);
        }
        else
        {
            finalMoveX = Mathf.Sign(animDirection.x);
            finalMoveY = 0.0f;
        }

        _animator.SetFloat(MoveX, finalMoveX);
        _animator.SetFloat(MoveY, finalMoveY);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * speed;
    }
}