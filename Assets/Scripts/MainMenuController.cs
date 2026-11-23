using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuPanel;

    [Header("Gameplay UI")]
    [SerializeField] private GameObject joystickBG;
    [SerializeField] private GameObject homeGame;

    private void Start()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (joystickBG != null)
            joystickBG.SetActive(false);

        if (homeGame != null)
            homeGame.SetActive(false);
    }

    // ==========================
    // START GAME
    // ==========================
    public void StartGame()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (joystickBG != null)
            joystickBG.SetActive(true);

        if (homeGame != null)
            homeGame.SetActive(true);
    }

    // ==========================
    // HOME DI GAME AR
    // ==========================
    public void HomeGame()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (joystickBG != null)
            joystickBG.SetActive(false);

        if (homeGame != null)
            homeGame.SetActive(false);
    }

    // ==========================
    // HOME DI MAIN MENU
    // ==========================
    public void HomeMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // ==========================
    // EXIT
    // ==========================
    public void QuitGame()
    {
        Application.Quit();
    }
}