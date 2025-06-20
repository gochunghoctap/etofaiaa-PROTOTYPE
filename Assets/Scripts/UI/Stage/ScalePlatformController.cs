using UnityEngine;

public class ScalePlatformController : MonoBehaviour
{
    public Transform leftPlate;
    public Transform rightPlate;

    public float moveAmount = 0.5f; // óhÇÍÇÃïù
    public float moveSpeed = 2.0f;  // óhÇÍÇÃë¨Ç≥

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float offset = Mathf.Sin((Time.time - startTime) * moveSpeed) * moveAmount;

        if (leftPlate != null)
            leftPlate.localPosition = new Vector3(leftPlate.localPosition.x, -offset, leftPlate.localPosition.z);

        if (rightPlate != null)
            rightPlate.localPosition = new Vector3(rightPlate.localPosition.x, offset, rightPlate.localPosition.z);
    }
}
