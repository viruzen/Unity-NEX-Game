using UnityEngine;
using TMPro; // For using TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText; 
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
        score = 0;
        if (winScreen != null)
            winScreen.SetActive(false); // Hide the win screen at the start
        scoreText.text = "Score: " + score; // Initialize the score text
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score incremented. Current score: " + score);

        scoreText.text = "Score: " + score;

        if (score == winScore)
        {
            ShowWinScreen();
        }
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}