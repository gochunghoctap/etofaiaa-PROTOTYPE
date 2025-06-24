using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform barTransform;
    public float smoothSpeed = 5f;

    private Vector3 originalScale;
    private float targetPercent = 1f;

    void Start()
    {
        // Lưu lại kích thước ban đầu để dùng làm gốc
        originalScale = barTransform.localScale;
    }

    public void SetHealthPercent(float percent)
    {
        targetPercent = Mathf.Clamp01(percent);
    }

    void Update()
    {
        float currentX = barTransform.localScale.x;
        float targetX = originalScale.x * targetPercent;
        float smoothedX = Mathf.Lerp(currentX, targetX, Time.deltaTime * smoothSpeed);

        barTransform.localScale = new Vector3(smoothedX, originalScale.y, originalScale.z);
    }
}
