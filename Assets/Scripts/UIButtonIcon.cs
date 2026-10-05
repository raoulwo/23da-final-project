using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class UIButtonIcon : MonoBehaviour
{
    private static readonly int Hover = Animator.StringToHash("Hover");
    
    [SerializeField] private Color notInteractableColor;
    
    private Button _button;
    private Image _icon;
    private Animator _animator;
    
    private void Start()
    {
        _button = GetComponentInParent<Button>();
        _icon = GetComponent<Image>();
        _animator = GetComponent<Animator>();

        if (!_button.interactable)
        {
            _icon.color = notInteractableColor;
        }
    }

    public void OnHoverEnter()
    {
        if (!_button.interactable)
        {
            return;
        }
        
        _animator.SetBool(Hover, true);
    }

    public void OnHoverExit()
    {
        if (!_button.interactable)
        {
            return;
        }
        
        _animator.SetBool(Hover, false);
    }

    public void OnPress()
    {
        if (!_button.interactable)
        {
            return;
        }
    }

    public void OnRelease()
    {
        if (!_button.interactable)
        {
            return;
        }
    }
}
