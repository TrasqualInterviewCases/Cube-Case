using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static Action OnPlayerDeath;

    [SerializeField] int baseHealth = 3;
    [SerializeField] Transform healthPanel;
    [SerializeField] GameObject healthPrefab;

    private int currentHealth;

    private void Start()
    {
        UpdateCurrentHealth();
        UpdatePlayerHealthPanel();
    }

    private void UpdatePlayerHealthPanel()
    {
        var dif = currentHealth - healthPanel.childCount;

        if (dif > 0)
        {
            for (int i = 0; i < dif; i++)
            {
                Instantiate(healthPrefab, healthPanel);
            }
        }
        else
        {
            dif = Mathf.Abs(dif);
            for (int i = 0; i < dif; i++)
            {
                Destroy(healthPanel.GetChild(0).gameObject);
            }
        }
    }

    public void UpdateCurrentHealth()
    {
        currentHealth = baseHealth + PlayerPrefs.GetInt("healthUpgradeLevel", 0);
        UpdatePlayerHealthPanel();
    }

    public bool CheckDeathOnDamageTaken(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdatePlayerHealthPanel();
            Die();
            return true;
        }
        UpdatePlayerHealthPanel();
        return false;
    }

    private void Die()
    {
        OnPlayerDeath?.Invoke();
        GameManager.Instance.LoseGame();
    }

    private void OnEnable()
    {
        BonusManager.OnHealthUpgraded += UpdateCurrentHealth;
    }

    private void OnDisable()
    {
        BonusManager.OnHealthUpgraded -= UpdateCurrentHealth;
    }
}
