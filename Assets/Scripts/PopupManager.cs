using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    public GameObject popupText;
    public GameObject popupLevel;

    void Awake()
    {
        instance = this; }

    public void TampilkanPopup()
    {
        StopAllCoroutines();
        StartCoroutine(ShowPopup()); }

    public void TampilkanPopupLevel(int level)
    {
        StartCoroutine(ShowPopupLevel(level));}

    IEnumerator ShowPopup()
    {
        popupText.SetActive(true);
        yield return new WaitForSeconds(1f);
        popupText.SetActive(false); }

    IEnumerator ShowPopupLevel(int level)
    {
        if (popupLevel != null)
        {
            Text t = popupLevel.GetComponent<Text>();
            if (t != null) t.text = "Level " + level + "!";
            popupLevel.SetActive(true);
            yield return new WaitForSeconds(2f);
            popupLevel.SetActive(false);}}}

            