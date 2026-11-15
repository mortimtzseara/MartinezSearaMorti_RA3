using Unity.VisualScripting;
using UnityEngine;

public class TurretDeactivate : MonoBehaviour
{
    [SerializeField] GameObject turret;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turret.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turret.SetActive(true);
        }
    }
}
