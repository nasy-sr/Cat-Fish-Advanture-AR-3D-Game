using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMemory : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenuPanel;

    [Header("Gameplay UI")]
    public GameObject gameBoard;
    public GameObject infoPanel;
    public GameObject homeButton;
    public GameObject restartButton;

    private void Start()
    {
        // Menu tampil saat awal
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        // Gameplay disembunyikan
        if (gameBoard != null)
            gameBoard.SetActive(false);

        if (infoPanel != null)
            infoPanel.SetActive(false);

        if (homeButton != null)
            homeButton.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);
    }

    // =====================
    // START GAME
    // =====================
    public void StartGame()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (gameBoard != null)
            gameBoard.SetActive(true);

        if (infoPanel != null)
            infoPanel.SetActive(true);

        if (homeButton != null)
            homeButton.SetActive(true);

        if (restartButton != null)
            restartButton.SetActive(true);
    }

    // =====================
    // HOME
    // =====================
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}