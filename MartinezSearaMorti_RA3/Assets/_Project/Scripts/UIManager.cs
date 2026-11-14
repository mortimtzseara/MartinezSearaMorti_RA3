using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI healthText;

    private DialogueData currentDialogue;
    private int currentLineIndex = 0;
    public static bool IsDialogueActive { get; private set; } = false;

    private void OnEnable()
    {
        GameEvents.OnDialogueRequested += StartDialogue;
        GameEvents.OnDialogueAdvanceRequested += DisplayNextLine;

        GameEvents.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        GameEvents.OnDialogueRequested -= StartDialogue;
        GameEvents.OnDialogueAdvanceRequested -= DisplayNextLine;
        GameEvents.OnHealthChanged -= UpdateHealthUI;

        IsDialogueActive = false;
    }

    private void Start()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    private void StartDialogue(DialogueData data)
    {
        if (IsDialogueActive) return;

        currentDialogue = data;
        currentLineIndex = 0;
        IsDialogueActive = true;

        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (!IsDialogueActive) return;

        if (currentLineIndex < currentDialogue.lines.Length)
        {
            dialogueText.text = currentDialogue.lines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            CloseDialogue();
        }
    }

    private void CloseDialogue()
    {
        IsDialogueActive = false;
        dialoguePanel.SetActive(false);
    }



    private void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth} / {maxHealth}";
        }
    }
}