using UnityEngine;

public class BarFollower : MonoBehaviour
{
    public Transform leftPlate;
    public Transform rightPlate;
    public Vector3 offset = Vector3.zero; // �C�ӂ̔�����

    void Update()
    {
        if (leftPlate != null && rightPlate != null)
        {
            // �R���_�[�̒��S�ł͂Ȃ��A�����ڂ̎M�̒��S��z�肵�Ĉʒu��␳
            Vector3 midPos = (leftPlate.position + rightPlate.position) / 2f;
            transform.position = midPos + offset;

            // �_�̊p�x���M�̈ʒu�x�[�X�Ōv�Z�iOK�j
            Vector3 dir = rightPlate.position - leftPlate.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
