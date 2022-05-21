using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;
    PlayerHealthManager healthManager;
    PlayerAnimationController anim;
    Transform model;
    IEnumerator obstacleHitCo;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        healthManager = GetComponent<PlayerHealthManager>();
        anim = GetComponent<PlayerAnimationController>();
        model = transform.GetChild(0);
    }

    public void HitObstacle(int damage)
    {
        if (healthManager.CheckDeathOnDamageTaken(damage))
        {
            movement.DisableMovement();
        }
        else
        {
            movement.ApplyHitMotion();
            StopHitCo();
            obstacleHitCo = HitObstacleCo();
            StartCoroutine(obstacleHitCo);
        }
    }

    IEnumerator HitObstacleCo()
    {
        yield return new WaitForSeconds(1.25f);
        movement.StopHitMotion();
    }

    private void StopHitCo()
    {
        if (obstacleHitCo != null)
        {
            StopCoroutine(obstacleHitCo);
        }
    }

    public void Finish()
    {
        StartCoroutine(FinishCo());
    }

    private IEnumerator FinishCo()
    {
        yield return new WaitForSeconds(0.5f);
        movement.DisableMovement();
        CameraSwitcher.Instance.SwitchToFinishCam();
        var targetAngle = new Vector3(0f, 180f, 0f);
        var targetRot = Quaternion.Euler(targetAngle);
        while (Vector3.Distance(model.eulerAngles, targetAngle)>0.01f)
        {
            model.rotation = Quaternion.Lerp(model.rotation, targetRot, Time.deltaTime * 10f);
            yield return null;
        }
        model.rotation = targetRot;
        anim.PlayWinAnim();
        GameManager.Instance.WinGame();
    }
}
