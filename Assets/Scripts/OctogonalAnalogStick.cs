using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class OctagonalAnalogStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Joystick Settings")]
    [Tooltip("Maximum distance the handle can move from the center.")]
    [SerializeField] private float handleRange = 100f;
    [Tooltip("Minimum drag distance required to register input.")]
    [SerializeField] private float deadZone = 0.1f;

    [Header("Output Events")]
    [Tooltip("Fires continuously while dragging, passing the 8-way normalized 2D vector.")]
    public Vector2Event onMoveInput;

    private RectTransform backgroundRect;
    private RectTransform handleRect;
    private Vector2 inputVector = Vector2.zero;

    void Awake()
    {
        handleRect = GetComponent<RectTransform>();
        // Assumes the parent object is your octagonal background
        if (transform.parent != null)
        {
            backgroundRect = transform.parent.GetComponent<RectTransform>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (backgroundRect == null) return;

        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            backgroundRect, 
            eventData.position, 
            eventData.pressEventCamera, 
            out position))
        {
            // Normalize input based on allowed handle range
            inputVector = position / handleRange;

            // Apply Deadzone
            if (inputVector.magnitude < deadZone)
            {
                inputVector = Vector2.zero;
            }
            else
            {
                // Clamp magnitude to max range (1.0)
                inputVector = Vector2.ClampMagnitude(inputVector, 1.0f);
                
                // Quantize to 8 directions (snap to nearest 45 degrees)
                inputVector = QuantizeTo8Way(inputVector);
            }

            // Move the handle visual position to match the snapped 8-way vector
            handleRect.anchoredPosition = inputVector * handleRange;

            // Send output vector to listeners (like your InputManager)
            onMoveInput?.Invoke(inputVector);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset position and input when released
        inputVector = Vector2.zero;
        handleRect.anchoredPosition = Vector2.zero;
        onMoveInput?.Invoke(inputVector);
    }

    private Vector2 QuantizeTo8Way(Vector2 rawInput)
    {
        // Calculate angle in degrees (0 to 360)
        float angle = Mathf.Atan2(rawInput.y, rawInput.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360f;

        // Divide into 8 sectors of 45 degrees each, and snap to the center of the sector
        float snappedAngle = Mathf.Round(angle / 45f) * 45f;
        float rad = snappedAngle * Mathf.Deg2Rad;

        // Return a clean normalized vector pointing to one of the 8 directions
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }
}

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2> {}

