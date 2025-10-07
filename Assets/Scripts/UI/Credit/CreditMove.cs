using UnityEngine;
using UnityEngine.UI;

/*public class CreditImageShift : MonoBehaviour
{
    public RectTransform imageToShift;// 2枚目のImageのRectTransform
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
*/
public class CreditImageShift : MonoBehaviour
{
    public Vector2 shiftDirection = new Vector2(1f, 0f);
    public float shiftSpeed = 10f;

    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            float shiftAmount = Time.deltaTime * shiftSpeed;
            rectTransform.anchoredPosition = originalPosition + shiftDirection * shiftAmount;
        }
    }
}


