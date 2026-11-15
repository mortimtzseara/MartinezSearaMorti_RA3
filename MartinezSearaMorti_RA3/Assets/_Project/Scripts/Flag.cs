using UnityEngine;

public class Flag : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
    public void Interact()
    {
        GameEvents.GameWin();
    }

}
