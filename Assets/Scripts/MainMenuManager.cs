using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayARGame()
    {
        SceneManager.LoadScene("ARGame");
    }

    public void PlayMemoryCard()
    {
        SceneManager.LoadScene("MemoryCardGame");
    }

    public void OpenHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OpenAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}