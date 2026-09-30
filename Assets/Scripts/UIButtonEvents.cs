using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>(); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_button.interactable)
        {
            return;
        }
        
        onHoverEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_button.interactable)
        {
            return;
        }
        
        onHoverExit?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_button.interactable)
        {
            return;
        }
        
        onPress?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_button.interactable)
        {
            return;
        }

        onRelease?.Invoke();
    }
}