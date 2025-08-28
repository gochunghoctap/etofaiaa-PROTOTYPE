using UnityEngine;

public class MagicShooter : MonoBehaviour
{
    private PlayerInput playerInput;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    private bool magicQueued = false;

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
            float direction = playerInput.MoveInput >= 0 ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);

            bullet.transform.localScale = new Vector3(
                direction * Mathf.Abs(bullet.transform.localScale.x),
                bullet.transform.localScale.y,
                bullet.transform.localScale.z
            );
        }

        Debug.Log("🔫 Bullet spawned at " + bulletSpawnPoint.position);
    }
}