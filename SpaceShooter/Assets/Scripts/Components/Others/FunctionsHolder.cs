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
}
