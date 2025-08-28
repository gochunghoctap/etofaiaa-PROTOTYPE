using UnityEngine;
using UnityEngine.UI;

public class CreditImageShift : MonoBehaviour
{
    public RectTransform imageToShift; // 2枚目のImageのRectTransform
    public Vector2 shiftDirection = new Vector2(1f, 0f); // 右方向にずらす
    public float shiftSpeed = 10f; // ピクセル/秒

    private Vector2 originalPosition;

    void Start()
    {
        if (imageToShift != null)
        {
            originalPosition = imageToShift.anchoredPosition;
        }
    }

    void Update()
    {
        if (imageToShift != null)
        {
            float shiftAmount = Time.time * shiftSpeed;
            imageToShift.anchoredPosition = originalPosition + shiftDirection * shiftAmount;
        }
    }
}