using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MeshRenderer))]
public class AnimateArcadeButton : MonoBehaviour
{
    private enum ButtonActionType
    {
        Attack,
        Defend,
        Jump,
        Magic,
    }
    
    [SerializeField] private ButtonActionType actionType;
    
    [SerializeField] private Material idleMaterial;
    [SerializeField] private Material pressedMaterial;
    
    private static readonly int IsPressed = Animator.StringToHash("IsPressed");
    
    private InputManager _inputManager;
    private Animator _animator;
    private MeshRenderer _meshRenderer;

    private bool _wasPressedLastFrame = false;
    
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _animator = GetComponent<Animator>();     
        _meshRenderer = GetComponent<MeshRenderer>();

        UpdateMaterial(false);
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

        if (isButtonPressed != _wasPressedLastFrame)
        {
            UpdateMaterial(isButtonPressed);
            _wasPressedLastFrame = isButtonPressed;
        }
    }

    private void UpdateMaterial(bool pressed)
    {
        _meshRenderer.material = pressed ? pressedMaterial : idleMaterial;
    }
}
