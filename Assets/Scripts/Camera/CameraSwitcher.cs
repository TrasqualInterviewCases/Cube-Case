using UnityEngine;

public class CameraSwitcher : Singleton<CameraSwitcher>
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject finishCam;

    public void SwitchToFinishCam()
    {
        playerCam.SetActive(false);
        finishCam.SetActive(true);
    }
}
