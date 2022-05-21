using System;

public class GameManager : Singleton<GameManager>
{
    public static Action OnWin;
    public static Action OnLose;
    public static Action OnStart;

    public void StartGame()
    {
        OnStart?.Invoke();
    }

    public void LoseGame()
    {
        OnLose?.Invoke();
    }

    public void WinGame()
    {
        OnWin?.Invoke();
    }
}
