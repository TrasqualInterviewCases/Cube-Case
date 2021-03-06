using UnityEngine;

public class PlayerCollectableHandler : MonoBehaviour
{
    public int CollectedGems { get; private set; }

    public int TotalGems { get; private set; }

    private void Start()
    {
        TotalGems = PlayerPrefs.GetInt("totalGems", 0);
        UIManager.Instance.SetTotalGemText(TotalGems);
    }

    public void Collect(int amount)
    {
        CollectedGems += amount + PlayerPrefs.GetInt("collectionUpgradeLevel",0);
        UIManager.Instance.PlayCoinCollectionAnim(CollectedGems);
    }

    public bool SpendGems(int amount)
    {
        if (TotalGems >= amount)
        {
            TotalGems -= amount;
            UIManager.Instance.SetTotalGemText(TotalGems);
            SaveGems();
            return true;
        }
        return false;
    }

    private void ResetGems()
    {
        CollectedGems = 0;
        UIManager.Instance.SetCollectedGemText(0);
    }

    private void SaveGems()
    {
        TotalGems += CollectedGems;
        PlayerPrefs.SetInt("totalGems", TotalGems);
    }

    private void OnEnable()
    {
        GameManager.OnLose += ResetGems;
        GameManager.OnWin += SaveGems;
    }

    private void OnDisable()
    {
        GameManager.OnLose -= ResetGems;
        GameManager.OnWin -= SaveGems;
    }
}
