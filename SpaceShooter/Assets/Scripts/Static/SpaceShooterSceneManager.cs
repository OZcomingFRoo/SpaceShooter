using UnityEngine.SceneManagement;

public static class SpaceShooterSceneManager 
{
    static byte CurrnetSceneLevelIndex;
    const byte START_SCREEN_SCENE_INDEX = 0;
    const byte LEVEL_COMPLETED_SCENE_INDEX = 1;
    const short FIRST_LEVEL_SCENE_INDEX = 2;

    public static int CurrentLevelCompleted { get { return CurrnetSceneLevelIndex - 2; } }

    static SpaceShooterSceneManager()
    {
        CurrnetSceneLevelIndex = 2 ;
    }

    public static void LoadNextLevelScene()
    {
        SceneManager.LoadScene(CurrnetSceneLevelIndex, LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads GameOver Screen
    /// NOTE! GameOver Scene name MUST NOT BE CHANGED
    /// </summary>
    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    /// <summary>
    /// Will go to start screen and reset "CurrnetSceneLevelIndex"
    /// </summary>
    public static void LoadStartScreen()
    {
        CurrnetSceneLevelIndex = (byte)FIRST_LEVEL_SCENE_INDEX;
        SceneManager.LoadScene(START_SCREEN_SCENE_INDEX, LoadSceneMode.Single);
    }

    /// <summary>
    /// Will load level completed scene and prepare player for the next level
    /// </summary>
    public static void LoadLevelCompletedScene()
    {
        CurrnetSceneLevelIndex++; // Incrament to the next level
        SceneManager.LoadScene(LEVEL_COMPLETED_SCENE_INDEX, LoadSceneMode.Single);
    }
}
