using UnityEngine;
using TMPro; // For using TextMeshPro
using UnityEngine.SceneManagement; // For scene management

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText; // Reference to the score text UI
    public GameObject winScreen; // Reference to the win screen UI

    private int score = 0;
    private const int winScore = 10; // Number of coins needed to win

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        score = 0; // Initialize the score to zero
        winScreen.SetActive(false); // Ensure the win screen is hidden at the start
        scoreText.text = "Score: " + score; // Initialize the score text
    }


    public void IncrementScore()
    {
        score++;
        Debug.Log("Score incremented. Current score: " + score); // Debug statement

        scoreText.text = "Score: " + score;

        // Check for win condition when the score is exactly equal to winScore
        if (score == winScore)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true); // Show the win screen
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void QuitGame()
    {
        // Log a message in the console (optional, for testing)
        Debug.Log("Quitting game...");

#if UNITY_EDITOR
        // If we're in the editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If we are running a standalone build, quit the application
            Application.Quit();
#endif
    }
}
