using System.Collections;
using UnityEngine;

public class WinPanelAnimation : MonoBehaviour
{
    public float animationTime = 0.3f;
    public float overshoot = 1.1f;

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(PopAnimation());
    }

    IEnumerator PopAnimation()
    {
        transform.localScale = Vector3.zero;

        float t = 0;

        while (t < 1)
        {
            transform.localScale = Vector3.Lerp(
                Vector3.zero,
                Vector3.one * overshoot,
                t);

            t += Time.deltaTime / animationTime;

            yield return null;
        }

        t = 0;

        while (t < 1)
        {
            transform.localScale = Vector3.Lerp(
                Vector3.one * overshoot,
                Vector3.one,
                t);

            t += Time.deltaTime / (animationTime * 0.5f);

            yield return null;
        }

        transform.localScale = Vector3.one;
    }
}