using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Start Panel Fields")]
    [SerializeField] GameObject startPanel;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text totalGemText;
    [SerializeField] GameObject shopPanel;

    [Header("Game Panel Fields")]
    [SerializeField] GameObject gamePanel;
    [SerializeField] TMP_Text collectableText;

    [Space(5)]
    [SerializeField] GameObject winPanel;

    [Space(5)]
    [SerializeField] GameObject losePanel;

    private void Start()
    {
        SetLevelText();
    }

    private void SetLevelText()
    {
        levelText.SetText($"Level {1}");
    }

    public void PlayCoinCollectionAnim(int amount)
    {
        SetCollectedGemText(amount);
    }

    public void SetCollectedGemText(int amount)
    {
        collectableText.SetText(amount.ToString());
    }

    public void SetTotalGemText(int amount)
    {
        totalGemText.SetText(amount.ToString());
    }

    private void OnGameStartCallback()
    {
        shopPanel.SetActive(false);
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void OnLoseCallback()
    {
        gamePanel.SetActive(false);
        losePanel.SetActive(true);
    }

    private  void OnWinCallback()
    {
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameManager.OnStart += OnGameStartCallback;
        GameManager.OnWin += OnWinCallback;
        GameManager.OnLose += OnLoseCallback;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= OnGameStartCallback;
        GameManager.OnWin -= OnWinCallback;
        GameManager.OnLose -= OnLoseCallback;
    }
}
