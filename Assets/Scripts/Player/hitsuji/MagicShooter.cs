using UnityEngine;

public class MagicShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput != null && playerInput.CurrentAction == ActionType.Magic)
        {
            ShootBullet();
            Invoke(nameof(ConsumeMagic), 0.01f); // delay nhẹ để chắc chắn frame sau mới reset
        }
    }

    void ConsumeMagic()
    {
        playerInput.ConsumeAction();
    }

    void ShootBullet()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Xác định hướng mặt của nhân vật
            float direction = transform.localScale.x >= 0 ? -1f : 1f;

            Vector2 shootDirection = new Vector2(direction, 0f); // bay ngang trái/phải

            rb.linearVelocity = shootDirection * bulletSpeed;

            // Không xoay viên đạn nếu không cần
            bullet.transform.rotation = Quaternion.identity;

            // Lật viên đạn theo hướng
            bullet.transform.localScale = new Vector3(
                direction * Mathf.Abs(bullet.transform.localScale.x),
                bullet.transform.localScale.y,
                bullet.transform.localScale.z
            );
        }
    }
}