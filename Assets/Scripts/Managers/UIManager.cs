using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Start Panel Fields")]
    [SerializeField] GameObject startPanel;
    [SerializeField] TMP_Text levelText;

    [Header("Game Panel Fields")]
    [SerializeField] GameObject gamePanel;
    [SerializeField] TMP_Text goldText;

    private void Start()
    {
        SetLevelText();
    }

    private void SetLevelText()
    {
        levelText.SetText($"Level {1}");
    }

    public void SetGoldText()
    {
        goldText.SetText(0.ToString());
    }

    private void OnGameStartCallback()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameManager.OnStart += OnGameStartCallback;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= OnGameStartCallback;
    }
}
