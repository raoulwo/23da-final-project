using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    
    public Vector2 MoveInput { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool DefendPressed { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool MagicPressed { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void HandleAttackButtonPressed()
    {
        AttackPressed = true;
    }

    public void HandleAttackButtonReleased()
    {
        AttackPressed = false;
    }

    public void HandleAttackButtonHoverEnter()
    {
        Debug.Log("ATTACK Hover Enter");
    }
    
    public void HandleAttackButtonHoverExit()
    {
        Debug.Log("ATTACK Hover Exit");
    }
    
    public void HandleDefendButtonPressed()
    {
        DefendPressed = true;
    }
    
    public void HandleDefendButtonReleased()
    {
        DefendPressed = false;
    }
    
    public void HandleDefendButtonHoverEnter()
    {
        Debug.Log("DEFEND Hover Enter");
    }
    
    public void HandleDefendButtonHoverExit()
    {
        Debug.Log("DEFEND Hover Exit");
    }
    
    public void HandleJumpButtonPressed()
    {
        JumpPressed = true;
    }
    
    public void HandleJumpButtonReleased()
    {
        JumpPressed = false;
    }
    
    public void HandleJumpButtonHoverEnter()
    {
        Debug.Log("JUMP Hover Enter");
    }
    
    public void HandleJumpButtonHoverExit()
    {
        Debug.Log("JUMP Hover Exit");
    }
    
    public void HandleMagicButtonPressed()
    {
        MagicPressed = true;
    }
    
    public void HandleMagicButtonReleased()
    {
        MagicPressed = false;
    }
    
    public void HandleMagicButtonHoverEnter()
    {
        Debug.Log("MAGIC Hover Enter");
    }
    
    public void HandleMagicButtonHoverExit()
    {
        Debug.Log("MAGIC Hover Exit");
    }

    public void HandleAnalogStickMove(Vector2 direction)
    {
        Debug.Log(direction);
        MoveInput = direction;
    }
}
