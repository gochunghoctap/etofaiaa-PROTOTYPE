using UnityEngine;

public class BarFollower : MonoBehaviour
{
    public Transform leftPlate;
    public Transform rightPlate;
    public Vector3 offset = Vector3.zero; // 任意の微調整

    void Update()
    {
        if (leftPlate != null && rightPlate != null)
        {
            // コリダーの中心ではなく、見た目の皿の中心を想定して位置を補正
            Vector3 midPos = (leftPlate.position + rightPlate.position) / 2f;
            transform.position = midPos + offset;

            // 棒の角度を皿の位置ベースで計算（OK）
            Vector3 dir = rightPlate.position - leftPlate.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
