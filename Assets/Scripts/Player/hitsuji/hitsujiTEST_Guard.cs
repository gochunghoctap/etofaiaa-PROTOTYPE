using UnityEngine;
using System.Collections;

public class hitsujiTEST_Guard : MonoBehaviour
{
    public PlayerController playerController;

    private void Awake()
    {
        if (playerController == null)
            playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            // Đỡ được Attack hoàn toàn – không mất máu, không bị stun
            Debug.Log($"{gameObject.name} đã đỡ thành công đòn Attack.");
        }
        else if (other.CompareTag("Magic"))
        {
            Debug.Log($"{gameObject.name} bị trúng Magic trong khi đang Guard!");

            // Gây stun trong 1 giây
            if (playerController != null)
                playerController.ApplyStunGuardBreak(1f); // Sử dụng phương thức stun có tham số
        }
    }
}
