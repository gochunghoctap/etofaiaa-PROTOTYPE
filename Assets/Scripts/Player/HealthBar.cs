using UnityEngine;
using System.Collections; // Thêm để dùng Coroutine

public class HealthBar : MonoBehaviour
{
    public Transform barTransform;
    public float smoothSpeed = 5f;

    private Vector3 originalScale;
    private float targetPercent = 1f;

    // ✅ Thêm biến để lưu vị trí ban đầu của thanh máu
    private Vector3 originalPosition;

    void Start()
    {
        originalScale = barTransform.localScale;
        originalPosition = transform.localPosition; // ✅ Lưu vị trí gốc
    }

    public void SetHealthPercent(float percent)
    {
        targetPercent = Mathf.Clamp01(percent);
    }

    // ✅ HÀM GÂY RUNG THANH MÁU
    public void Shake(float duration = 0.2f, float magnitude = 5f)
    {
        StopAllCoroutines(); // Dừng hiệu ứng cũ nếu đang rung
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    // ✅ Coroutine để xử lý rung
    IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    void Update()
    {
        float currentScaleX = barTransform.localScale.x;
        float targetScaleX = originalScale.x * targetPercent;
        float smoothedScaleX = Mathf.Lerp(currentScaleX, targetScaleX, Time.deltaTime * smoothSpeed);

        barTransform.localScale = new Vector3(smoothedScaleX, originalScale.y, originalScale.z);
    }
}
