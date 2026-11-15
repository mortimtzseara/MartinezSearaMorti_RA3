using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    [SerializeField] GameObject respawn;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        GameEvents.OnTakeDamage += Respawn;
    }
    private void OnDisable()
    {
        GameEvents.OnTakeDamage -= Respawn;
    }    
    
    private void Respawn()
    {
        gameObject.transform.position = respawn.transform.position;
        rb.gravityScale = 5;
        if (sr.flipY)
        {
            sr.flipY = false;
        }
        rb.linearVelocity = new Vector2(0f,0f);
    }
}
