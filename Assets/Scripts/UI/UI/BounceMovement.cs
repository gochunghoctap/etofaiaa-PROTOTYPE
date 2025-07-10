using UnityEngine;

public class BounceMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �����_���ȕ����ɏ�����^����
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���˂���悤�ɓ����̕�����ς���
        Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
        rb.linearVelocity = reflectDir * speed;
    }
}