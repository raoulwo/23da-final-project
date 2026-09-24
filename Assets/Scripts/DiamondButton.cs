using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DiamondButton : MonoBehaviour, ICanvasRaycastFilter
{
    private Image image;
    private RectTransform rectTransform;

    [Header("Hitbox & Alpha Settings")]
    [Range(0.01f, 1.0f)]
    public float alphaThreshold = 0.1f;

    [Header("Bounds Settings")]
    [Range(0.0f, 0.49f)]
    public float boundsPadding = 0.0f;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = transform as RectTransform;
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (image.sprite == null) return false;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, 
            sp, 
            eventCamera, 
            out Vector2 localPoint
        );

        Rect rect = rectTransform.rect;
        Sprite spr = image.sprite;
        Texture2D tex = spr.texture;

        float normX = (localPoint.x - rect.x) / rect.width;
        float normY = (localPoint.y - rect.y) / rect.height;

        if (normX < boundsPadding || normX > (1f - boundsPadding) || normY < boundsPadding || normY > (1f - boundsPadding)) 
            return false;

        Rect textureRect = spr.textureRect;
        int x = Mathf.FloorToInt(textureRect.x + normX * textureRect.width);
        int y = Mathf.FloorToInt(textureRect.y + normY * textureRect.height);

        try
        {
            Color pixel = tex.GetPixel(x, y);
            return pixel.a >= alphaThreshold;
        }
        catch (Exception e)
        {
            // Hier sehen wir jetzt im Unity-Log, WARUM es fehlschlägt!
            Debug.LogWarning("DiamondButton Error: " + e.Message);
            return true;
        }
    }
}
