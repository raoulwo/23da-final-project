using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateArcadeStick : MonoBehaviour
{
    private static readonly int StickX = Animator.StringToHash("StickX");
    private static readonly int StickY = Animator.StringToHash("StickY");
    
    private InputManager _inputManager;
    private Animator _animator;
    
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var moveInput = _inputManager.MoveInput;
        
        _animator.SetFloat(StickX, moveInput.x);
        _animator.SetFloat(StickY, moveInput.y);
    }
}
