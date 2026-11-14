using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<string> OnSceneChanged;
    public static event Action<DialogueData> OnDialogueRequested;
    public static event Action OnDialogueAdvanceRequested;

    public static void SceneChanged(string sceneName) => OnSceneChanged?.Invoke(sceneName);
    public static void RequestDialogue(DialogueData data) => OnDialogueRequested?.Invoke(data);
    public static void RequestAdvanceDialogue() => OnDialogueAdvanceRequested?.Invoke();
}
