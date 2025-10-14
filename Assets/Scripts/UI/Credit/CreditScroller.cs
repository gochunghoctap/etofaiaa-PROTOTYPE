using UnityEngine;

public class CreditScroller : MonoBehaviour
{
    public RectTransform contentTransform; // スクロール対象
    public float scrollSpeed = 50f; // スクロール速度（ピクセル/秒）

    private Vector2 startPos;

    void Start()
    {
        startPos = contentTransform.anchoredPosition;
    }

    void Update()
    {
        contentTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.unscaledDeltaTime;
    }

    public void ResetScroll()
    {
        contentTransform.anchoredPosition = startPos;
    }
}