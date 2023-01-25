using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameStateManager
{

    public static string LoadedScene = null;
    public static float Number = 0;

    public static Vector3 PlayerPosition = Vector3.zero;

    public static void LoadScene(string scene)
    {
        Number += 1;
        LoadedScene = scene;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
