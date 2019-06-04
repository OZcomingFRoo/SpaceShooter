using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SpaceShooterSceneManager 
{
    static byte CurrnetSceneLevelIndex;
    const byte START_SCREEN_SCENE_INDEX = 0;

    static SpaceShooterSceneManager()
    {
        CurrnetSceneLevelIndex = 1;
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(CurrnetSceneLevelIndex, LoadSceneMode.Single);
        CurrnetSceneLevelIndex++; // Incrament to the next level
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    /// <summary>
    /// Will go to start screen and reset "CurrnetSceneLevelIndex"
    /// </summary>
    public static void LoadStartScreen()
    {
        CurrnetSceneLevelIndex = 1;
        SceneManager.LoadScene(START_SCREEN_SCENE_INDEX, LoadSceneMode.Single);
    }
}
