using UnityEngine;

public class KingInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject buttonIcon;
    [SerializeField] private DialogueData dialogueData;

    private void Awake()
    {
        if (buttonIcon != null)
            buttonIcon.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonIcon.SetActive(false);
    }
    public void Interact()
    {
        GameEvents.RequestDialogue(dialogueData);
    }
}
