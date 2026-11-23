using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MemoryGameManager : MonoBehaviour
{
    //====================================================
    // PREFAB
    //====================================================

    [Header("Prefab")]
    public GameObject cardPrefab;

    //====================================================
    // BOARD
    //====================================================

    [Header("Board")]
    public Transform gameBoard;
    public GridLayoutGroup grid;
    public RectTransform boardRect;

    //====================================================
    // CARD SPRITES
    //====================================================

    [Header("Cards")]
    public Sprite cardBack;
    public Sprite[] cardFronts;

    //====================================================
    // UI
    //====================================================

    [Header("Panels")]
    public GameObject levelPanel;
    public GameObject winPanel;

    [Header("Gameplay UI")]
    public TMP_Text scoreText;
    public TMP_Text movesText;
    public TMP_Text timeText;

    [Header("Win UI")]
    public TMP_Text winScoreText;
    public TMP_Text winMovesText;
    public TMP_Text winTimeText;

    [Header("Effects")]
    public ParticleSystem winConfetti;

    //====================================================
    // GAME DATA
    //====================================================

    private List<CardData> gameCards = new List<CardData>();

    private Card firstCard;
    private Card secondCard;

    private bool canClick = false;
    private bool gameFinished = false;

    private int matchedPairs = 0;
    private int score = 0;
    private int moves = 0;

    private int totalPairs = 6;

    private float timer = 0f;

    //====================================================
    // GRID SETTINGS
    //====================================================

    [Header("Grid")]

    [SerializeField]
    private float spacing = 8f;

    [SerializeField]
    private float boardPadding = 10f;

        //====================================================
    // START
    //====================================================

    void Start()
    {
        if (levelPanel != null)
            levelPanel.SetActive(true);

        if (gameBoard != null)
            gameBoard.gameObject.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        score = 0;
        moves = 0;
        matchedPairs = 0;
        timer = 0f;

        UpdateUI();
    }

    //====================================================
    // UPDATE
    //====================================================

    void Update()
    {
        if (!canClick)
            return;

        if (gameFinished)
            return;

        timer += Time.deltaTime;

        int minute = Mathf.FloorToInt(timer / 60);
        int second = Mathf.FloorToInt(timer % 60);

        if (timeText != null)
            timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    //====================================================
    // LEVEL BUTTON
    //====================================================

    public void SelectEasy()
    {
        StartGame(6);
    }

    public void SelectMedium()
    {
        StartGame(10);
    }

    public void SelectHard()
    {
        StartGame(15);
    }

    //====================================================
    // START GAME
    //====================================================

    void StartGame(int pairs)
    {
        totalPairs = pairs;

        score = 0;
        moves = 0;
        matchedPairs = 0;
        timer = 0f;

        firstCard = null;
        secondCard = null;

        canClick = true;
        gameFinished = false;

        UpdateUI();

        if (levelPanel != null)
            levelPanel.SetActive(false);

        if (gameBoard != null)
            gameBoard.gameObject.SetActive(true);

        if (winPanel != null)
            winPanel.SetActive(false);

        CreateCards();
    }

    //====================================================
    // UPDATE UI
    //====================================================

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();

        if (movesText != null)
            movesText.text = moves.ToString();

        if (timeText != null)
            timeText.text = "00:00";
    }

        //====================================================
    // CREATE CARDS
    //====================================================

    void CreateCards()
    {
        // Hapus kartu lama
        foreach (Transform child in gameBoard)
        {
            Destroy(child.gameObject);
        }

        gameCards.Clear();

        // Membuat pasangan kartu
        for (int i = 0; i < totalPairs; i++)
        {
            gameCards.Add(new CardData(cardFronts[i], i));
            gameCards.Add(new CardData(cardFronts[i], i));
        }

        // Acak kartu
        Shuffle(gameCards);

        // Atur ukuran grid
        SetupGrid();

        // Spawn kartu
        foreach (CardData data in gameCards)
        {
            GameObject obj = Instantiate(cardPrefab, gameBoard);

            Card card = obj.GetComponent<Card>();

            if (card != null)
            {
                card.SetManager(this);
                card.SetCard(data.sprite, cardBack, data.id);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(boardRect);
    }

    //====================================================
    // SETUP GRID
    //====================================================

    void SetupGrid()
    {
        int columns;
        int rows;

        switch (totalPairs)
        {
            case 6:     // Easy
                columns = 4;
                rows = 3;
                break;

            case 10:    // Medium
                columns = 4;
                rows = 5;
                break;

            default:    // Hard
                columns = 5;
                rows = 6;
                break;
        }

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = columns;

        grid.spacing = new Vector2(spacing, spacing);
        grid.padding = new RectOffset(5, 5, 5, 5);

        LayoutRebuilder.ForceRebuildLayoutImmediate(boardRect);

        float width = boardRect.rect.width;
        float height = boardRect.rect.height;

        float cellWidth =
            (width - (columns - 1) * spacing - 10f) / columns;

        float cellHeight =
            (height - (rows - 1) * spacing - 10f) / rows;

        float cell = Mathf.Min(cellWidth, cellHeight);

        // Diperkecil sedikit supaya tidak memenuhi seluruh area
        cell *= 0.90f;

        grid.cellSize = new Vector2(cell, cell);
    }

    //====================================================
    // SHUFFLE
    //====================================================

    void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            CardData temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

        //====================================================
    // CARD SELECTED
    //====================================================

    public void CardSelected(Card card)
    {
        if (!canClick)
            return;

        if (card == null)
            return;

        if (card.IsMatched())
            return;

        if (firstCard == null)
        {
            firstCard = card;
            return;
        }

        if (card == firstCard)
            return;

        secondCard = card;

        moves++;

        if (movesText != null)
            movesText.text = moves.ToString();

        canClick = false;

        StartCoroutine(CheckMatch());
    }

    //====================================================
    // CHECK MATCH
    //====================================================

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.8f);

        if (firstCard.GetID() == secondCard.GetID())
        {
            firstCard.Match();
            secondCard.Match();

            matchedPairs++;

            score += 100;

            if (scoreText != null)
                scoreText.text = score.ToString();

            if (matchedPairs >= totalPairs)
            {
                gameFinished = true;
                canClick = false;

                if (GameAudioManager.Instance != null)
                    GameAudioManager.Instance.PlayWin();

                if (winConfetti != null)
                {
                    winConfetti.Clear();
                    winConfetti.Play();
                }

                if (winScoreText != null)
                    winScoreText.text = score.ToString();

                if (winMovesText != null)
                    winMovesText.text = moves.ToString();

                if (winTimeText != null)
                    winTimeText.text = timeText.text;

                if (winPanel != null)
                    winPanel.SetActive(true);
            }
        }
        else
        {
            firstCard.FlipBack();
            secondCard.FlipBack();
        }

        firstCard = null;
        secondCard = null;

        if (!gameFinished)
            canClick = true;
    }

    //====================================================
    // BUTTONS
    //====================================================

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //====================================================
    // RESET GAME
    //====================================================

    public void ResetGame()
    {
        StopAllCoroutines();

        firstCard = null;
        secondCard = null;

        matchedPairs = 0;
        score = 0;
        moves = 0;
        timer = 0f;

        canClick = false;
        gameFinished = false;

        UpdateUI();

        if (winPanel != null)
            winPanel.SetActive(false);

        if (winConfetti != null)
            winConfetti.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        foreach (Transform child in gameBoard)
            Destroy(child.gameObject);

        gameCards.Clear();

        if (gameBoard != null)
            gameBoard.gameObject.SetActive(false);

        if (levelPanel != null)
            levelPanel.SetActive(true);
    }

    //====================================================
    // GETTER
    //====================================================

    public bool CanClick()
    {
        return canClick;
    }
}

//====================================================
// CARD DATA
//====================================================

[System.Serializable]
public class CardData
{
    public Sprite sprite;
    public int id;

    public CardData(Sprite sprite, int id)
    {
        this.sprite = sprite;
        this.id = id;
    }
}