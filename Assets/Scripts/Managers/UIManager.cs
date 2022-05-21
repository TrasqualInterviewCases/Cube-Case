using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;

    private void OnGameStartCallback()
    {
        startPanel.SetActive(false);
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
