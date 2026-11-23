using UnityEngine;
using UnityEngine.UI;

public class SkorManager : MonoBehaviour
{
    public static SkorManager instance;
    public Text skorText;
    private int skor = 0;

    void Awake()
    {
        instance = this;
    }

    public void TambahSkor(int nilai)
    {
        skor += nilai;
        skorText.text = "Skor: " + skor;
    }
}


