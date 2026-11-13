using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<string> OnSceneChanged;

    public static void SceneChanged(string sceneName)
    {
        OnSceneChanged?.Invoke(sceneName);
    }
}
