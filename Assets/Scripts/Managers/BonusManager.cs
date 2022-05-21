using System;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public static Action OnHealthUpgraded;
    public static Action OnCollectionUpgraded;

    [SerializeField] PlayerCollectableHandler player;

    [Header("Upgrade Data")]
    [SerializeField] int collectionUpgradeBaseCost = 20;
    [SerializeField] int collectionUpgradeCostIncrement = 20;
    [SerializeField] int healthUpgradeBaseCost = 100;
    [SerializeField] int healthUpgradeCostIncrement = 100;

    private int collectionUpgradeLevel => PlayerPrefs.GetInt("collectionUpgradeLevel", 0);
    private int healthUpgradeLevel => PlayerPrefs.GetInt("healthUpgradeLevel", 0);

    private int collectionCost => collectionUpgradeBaseCost + collectionUpgradeLevel * collectionUpgradeCostIncrement;
    private int healthCost => healthUpgradeBaseCost + healthUpgradeLevel * healthUpgradeCostIncrement;

    private void Start()
    {
        UIManager.Instance.UpdateUpgradeButtonTexts(collectionCost, healthCost);
    }

    public void BuyCollectionUpgrade()
    {
        if (player.SpendGems(collectionCost))
        {
            var upgradeLevel = collectionUpgradeLevel + 1;
            PlayerPrefs.SetInt("collectionUpgradeLevel", upgradeLevel);
            UIManager.Instance.UpdateCollectionUpgradeButtonText(collectionCost);
            OnCollectionUpgraded?.Invoke();
        }
    }

    public void BuyHealthUpgrade()
    {
        if (player.SpendGems(healthCost))
        {
            var upgradeLevel = healthUpgradeLevel + 1;
            PlayerPrefs.SetInt("healthUpgradeLevel", upgradeLevel);
            UIManager.Instance.UpdateHealthUpgradeButtonText(healthCost);
            OnHealthUpgraded?.Invoke();
        }
    }
}

