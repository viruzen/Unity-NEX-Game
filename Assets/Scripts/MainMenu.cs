using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game
    public void PlayGame()
    {
        // Loading the main game scene
        SceneManager.LoadScene("Game");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game"); 

#if UNITY_EDITOR
        // If running in the Unity editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If in a built game, quit the application
        Application.Quit();
#endif
    }
}
