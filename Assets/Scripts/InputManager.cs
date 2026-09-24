using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void HandleAttackButtonClicked()
    {
        Debug.Log("ATTACK Clicked");
    }

    public void HandleAttackButtonHoverEnter()
    {
        Debug.Log("ATTACK Hover Enter");
    }
    
    public void HandleAttackButtonHoverExit()
    {
        Debug.Log("ATTACK Hover Exit");
    }
    
    public void HandleDefendButtonClicked()
    {
        Debug.Log("DEFEND Clicked");
    }
    
    public void HandleDefendButtonHoverEnter()
    {
        Debug.Log("DEFEND Hover Enter");
    }
    
    public void HandleDefendButtonHoverExit()
    {
        Debug.Log("DEFEND Hover Exit");
    }
    
    public void HandleJumpButtonClicked()
    {
        Debug.Log("JUMP Clicked");
    }
    
    public void HandleJumpButtonHoverEnter()
    {
        Debug.Log("JUMP Hover Enter");
    }
    
    public void HandleJumpButtonHoverExit()
    {
        Debug.Log("JUMP Hover Exit");
    }
    
    public void HandleMagicButtonClicked()
    {
        Debug.Log("MAGIC Clicked");
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
    }
}
