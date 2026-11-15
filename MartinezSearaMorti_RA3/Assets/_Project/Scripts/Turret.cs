using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float visionRange = 6f;
    [SerializeField] private BulletPool bulletPool;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float timeBetweenShots = 1f;
    private float nextShotTime = 0;


    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange);
        Debug.DrawRay(transform.position, direction * visionRange, Color.yellow);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {

            if (Time.time >= nextShotTime)
            {
                Shoot(direction);
                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }
    void Shoot(Vector2 direction)
    {       

        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;

        GameObject bullet = bulletPool.GetObject(spawnPosition);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }

}