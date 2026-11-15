using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public BulletPool bulletPool;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameEvents.TakeDamage();
            bulletPool.ReturnObject(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Spikes"))
        {
            bulletPool.ReturnObject(gameObject);
        }
    }
}