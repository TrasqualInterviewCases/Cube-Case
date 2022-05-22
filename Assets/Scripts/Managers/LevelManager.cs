using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] levelPrefabs;

    int currentLevelIndex;

    private void Start()
    {
        if (PlayerPrefs.GetInt("allLevelsCompleted") == 1)
        {
            var randLevel = Random.Range(0, levelPrefabs.Length);
            currentLevelIndex = randLevel;
        }
        else
        {
            currentLevelIndex = PlayerPrefs.GetInt("level", 0);
        }
        LoadLevelAtIndex();
    }

    private void LoadLevelAtIndex()
    {
        Instantiate(levelPrefabs[currentLevelIndex]);
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex > levelPrefabs.Length - 1)
        {
            PlayerPrefs.SetInt("allLevelsCompleted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("level", currentLevelIndex);
        }
        var levelNo = PlayerPrefs.GetInt("levelText", 1);
        PlayerPrefs.SetInt("levelText", levelNo + 1);
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
