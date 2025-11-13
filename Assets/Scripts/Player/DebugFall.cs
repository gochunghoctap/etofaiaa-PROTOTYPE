using UnityEngine;

public class DebugFall : MonoBehaviour
{
    [Header("Thiết lập chiều cao")]
    private float desiredHeight = -17f;     // Độ cao mong muốn

    void Update()
    {
        // Lấy vị trí hiện tại của nhân vật (2D)
        Vector3 currentPosition = transform.position;

        // Kiểm tra nếu độ cao Y thấp hơn ngưỡng
        if (currentPosition.y < desiredHeight)
        {
            // Gán lại độ cao Y theo mong muốn
            currentPosition.y = desiredHeight;
            transform.position = currentPosition;

            Debug.Log("Đã cập nhật độ cao Y của nhân vật 2D.");
        }
    }
}