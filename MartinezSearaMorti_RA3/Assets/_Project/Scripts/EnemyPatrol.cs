using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float speed = 2f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flip"))
        {
            speed *= -1;
            sr.flipX = !sr.flipX;
        }
        else if(collision.CompareTag("Player"))
        {
            GameEvents.TakeDamage();
        }
    }
}
