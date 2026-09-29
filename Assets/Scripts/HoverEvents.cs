using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HoverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;

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
}