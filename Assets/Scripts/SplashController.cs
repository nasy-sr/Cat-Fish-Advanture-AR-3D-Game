using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class SplashController : MonoBehaviour
{
    public TMP_Text loadingText;

    IEnumerator Start()
    {
        StartCoroutine(LoadingAnimation());

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadingAnimation()
    {
        while (true)
        {
            loadingText.text = "Loading.";
            yield return new WaitForSeconds(0.3f);

            loadingText.text = "Loading..";
            yield return new WaitForSeconds(0.3f);

            loadingText.text = "Loading...";
            yield return new WaitForSeconds(0.3f);
        }
    }
}