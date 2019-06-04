using UnityEngine;

public class FunctionsHolder : MonoBehaviour
{
    public void TestFunctionHolder()
    {
        Debug.Log("You press button");
    }

    public void QuitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }

    public void ReturnToStartMenu()
    {
        SpaceShooterSceneManager.LoadStartScreen();
    }

    public void StartGame()
    {
        SpaceShooterSceneManager.LoadNextLevelScene();
    }

    public void LoadNextLevel()
    {
        SpaceShooterSceneManager.LoadNextLevelScene();
    }
        
}
