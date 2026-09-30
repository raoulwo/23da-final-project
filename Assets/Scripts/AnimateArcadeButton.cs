using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateArcadeButton : MonoBehaviour
{
    public enum ButtonActionType
    {
        Attack,
        Defend,
        Jump,
        Magic,
    }
    
    [SerializeField] private ButtonActionType actionType;
    
    private static readonly int IsPressed = Animator.StringToHash("IsPressed");
    
    private InputManager _inputManager;
    private Animator _animator;
    
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _animator = GetComponent<Animator>();     
    }

    private void Update()
    {
        var isButtonPressed = actionType switch
        {
            ButtonActionType.Attack => _inputManager.AttackPressed,
            ButtonActionType.Defend => _inputManager.DefendPressed,
            ButtonActionType.Jump => _inputManager.JumpPressed,
            ButtonActionType.Magic => _inputManager.MagicPressed,
            _ => throw new ArgumentOutOfRangeException()
        };

        _animator.SetBool(IsPressed, isButtonPressed);
    }
}
