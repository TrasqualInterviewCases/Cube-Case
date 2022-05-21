using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static Action OnPlayerDeath;

    [SerializeField] int baseHealth = 3;

    private int currentHealth;

    private void Start()
    {
        currentHealth = baseHealth = PlayerPrefs.GetInt("playerHealth", 3);
    }

    public void IncreaseHealth(int amount)
    {
        baseHealth += amount;
        PlayerPrefs.SetInt("playerHealth", baseHealth);
    }

    public bool CheckDeathOnDamageTaken(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        OnPlayerDeath?.Invoke();
    }
}
