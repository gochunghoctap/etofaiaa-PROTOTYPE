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
            // Đỡ thành công - không mất máu, không bị stun
            Debug.Log($"{gameObject.name} đã đỡ thành công đòn Attack.");
        }
        else if (other.CompareTag("Magic"))
        {
            Debug.Log($"{gameObject.name} bị trúng Magic trong khi đang Guard!");

            if (playerController != null)
            {
                // Gây stun 1 giây
                playerController.ApplyStun(1f);

                // Kết thúc hành động Guard (cho phép input trở lại sau animation)
                playerController.EndAction();
            }
        }
    }
}
