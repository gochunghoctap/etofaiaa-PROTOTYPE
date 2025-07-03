using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform barTransform;
    public float smoothSpeed = 5f;

    private Vector3 originalScale;
    private float targetPercent = 1f;


    void Start()
    {
        originalScale = barTransform.localScale;
    }

    public void SetHealthPercent(float percent)
    {
        targetPercent = Mathf.Clamp01(percent);

    }

    void Update()
    {
        float currentScaleX = barTransform.localScale.x;
        float targetScaleX = originalScale.x * targetPercent;
        float smoothedScaleX = Mathf.Lerp(currentScaleX, targetScaleX, Time.deltaTime * smoothSpeed);

        barTransform.localScale = new Vector3(smoothedScaleX, originalScale.y, originalScale.z);
    }
}
