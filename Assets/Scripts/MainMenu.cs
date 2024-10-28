using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game
    public void PlayGame()
    {
        // Load the main game scene by name (e.g., "GameScene")
        SceneManager.LoadScene("Game");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Log quit action for testing

#if UNITY_EDITOR
        // If running in the Unity editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If in a built game, quit the application
        Application.Quit();
#endif
    }
}
