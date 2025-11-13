using UnityEngine;
using System.Collections;

public class MagicShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private float bulletSpeed = 20f;

    private PlayerInput playerInput;
    private ActionType lastAction = ActionType.None;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        StartCoroutine(WatchMagicAction());
    }

    IEnumerator WatchMagicAction()
    {
        while (true)
        {
            if (playerInput != null)
            {
                ActionType current = playerInput.CurrentAction;

                // Chỉ xử lý khi hành động Magic vừa được kích hoạt
                if (current == ActionType.Magic && lastAction != ActionType.Magic)
                {
                    ShootBullet();
                    yield return new WaitForSeconds(0.02f); // delay nhẹ để tránh xung đột
                    playerInput.ConsumeAction();
                }

                lastAction = current;
            }

            yield return null;
        }
    }

    void ShootBullet()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float direction = transform.localScale.x >= 0 ? -1f : 1f;
            Vector2 shootDirection = new Vector2(direction, 0f);
            rb.linearVelocity = shootDirection * bulletSpeed;

            if (direction < 0)
            {
                bullet.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }
}