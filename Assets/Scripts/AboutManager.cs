using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutManager : MonoBehaviour
{
    public void Home()
    {
        Debug.Log("Tombol HOME ditekan");
        SceneManager.LoadScene("MainMenu");
    }
}