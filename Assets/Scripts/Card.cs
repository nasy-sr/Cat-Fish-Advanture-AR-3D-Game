using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector]
    public int cardID;

    [HideInInspector]
    public bool isFlipped = false;

    [HideInInspector]
    public bool isMatched = false;

    private Sprite frontSprite;
    private Sprite backSprite;

    private Image image;
    private Button button;

    private MemoryGameManager manager;

    [Header("Animation")]
    [SerializeField] private float flipDuration = 0.15f;
    [SerializeField] private float bounceScale = 1.08f;
    [SerializeField] private float bounceSpeed = 10f;

    private bool isAnimating = false;

    void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnCardClicked);
        }

        transform.localScale = Vector3.one;
    }

    //==================================
    // SET MANAGER
    //==================================

    public void SetManager(MemoryGameManager gameManager)
    {
        manager = gameManager;
    }

    //==================================
    // SET CARD
    //==================================

    public void SetCard(Sprite front, Sprite back, int id)
    {
        frontSprite = front;
        backSprite = back;
        cardID = id;

        ResetCard();
    }

    //==================================
    // CLICK
    //==================================

    public void OnCardClicked()
    {
        if (manager == null)
            return;

        if (!manager.CanClick())
            return;

        if (isMatched)
            return;

        if (isFlipped)
            return;

        if (isAnimating)
            return;

        StartCoroutine(FlipAnimation(true));
    }

    //==================================
    // FLIP
    //==================================

    public void FlipCard()
    {
        if (!isAnimating)
            StartCoroutine(FlipAnimation(true));
    }

    //==================================
    // FLIP BACK
    //==================================

    public void FlipBack()
    {
        if (isMatched)
            return;

        if (!isAnimating)
            StartCoroutine(FlipAnimation(false));
    }

    //==================================
    // FLIP ANIMATION
    //==================================

    IEnumerator FlipAnimation(bool showFront)
    {
        isAnimating = true;

        Vector3 scale = transform.localScale;

        // Mengecil
        while (scale.x > 0f)
        {
            scale.x -= Time.deltaTime / flipDuration;

            if (scale.x < 0f)
                scale.x = 0f;

            transform.localScale = scale;

            yield return null;
        }

        // Ganti Sprite
        if (showFront)
        {
            image.sprite = frontSprite;
            isFlipped = true;

            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlayFlip();

            // Penting!
            manager.CardSelected(this);
        }
        else
        {
            image.sprite = backSprite;
            isFlipped = false;
        }

        // Membesar
        while (scale.x < 1f)
        {
            scale.x += Time.deltaTime / flipDuration;

            if (scale.x > 1f)
                scale.x = 1f;

            transform.localScale = scale;

            yield return null;
        }

        transform.localScale = Vector3.one;
                //=========================
        // Bounce
        //=========================

        if (showFront)
            yield return StartCoroutine(Bounce());

        isAnimating = false;
    }

    //==================================
    // BOUNCE
    //==================================

    IEnumerator Bounce()
    {
        Vector3 normal = Vector3.one;
        Vector3 big = Vector3.one * bounceScale;

        float t = 0f;

        while (t < 1f)
        {
            transform.localScale = Vector3.Lerp(normal, big, t);

            t += Time.deltaTime * bounceSpeed;

            yield return null;
        }

        t = 0f;

        while (t < 1f)
        {
            transform.localScale = Vector3.Lerp(big, normal, t);

            t += Time.deltaTime * bounceSpeed;

            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    //==================================
    // MATCH
    //==================================

    public void Match()
    {
        isMatched = true;
        isFlipped = true;

        if (button != null)
            button.interactable = false;

        if (GameAudioManager.Instance != null)
            GameAudioManager.Instance.PlayMatch();

        StartCoroutine(MatchEffect());
    }

    //==================================
    // MATCH EFFECT
    //==================================

    IEnumerator MatchEffect()
    {
        Vector3 start = Vector3.one;
        Vector3 end = Vector3.one * 1.15f;

        float t = 0f;

        while (t < 1f)
        {
            transform.localScale = Vector3.Lerp(start, end, t);

            t += Time.deltaTime * 8f;

            yield return null;
        }

        t = 0f;

        while (t < 1f)
        {
            transform.localScale = Vector3.Lerp(end, start, t);

            t += Time.deltaTime * 8f;

            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    //==================================
    // RESET
    //==================================

    public void ResetCard()
    {
        StopAllCoroutines();

        isAnimating = false;
        isMatched = false;
        isFlipped = false;

        transform.localScale = Vector3.one;

        if (image != null)
            image.sprite = backSprite;

        if (button != null)
            button.interactable = true;
    }
        //==================================
    // GETTER
    //==================================

    public Sprite GetFrontSprite()
    {
        return frontSprite;
    }

    public int GetID()
    {
        return cardID;
    }

    public bool IsMatched()
    {
        return isMatched;
    }

    public bool IsFlipped()
    {
        return isFlipped;
    }

    public bool IsAnimating()
    {
        return isAnimating;
    }
}