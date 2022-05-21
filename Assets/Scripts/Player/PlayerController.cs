using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;
    PlayerHealthManager healthManager;

    IEnumerator obstacleHitCo;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        healthManager = GetComponent<PlayerHealthManager>();
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
        yield return new WaitForSeconds(1.5f);
        movement.DisableMovement();
        while(transform.eulerAngles.y <= 180f)
        {
            var angles = transform.eulerAngles;
            angles.y += Time.deltaTime * 30f;
            transform.eulerAngles = angles;

            var targetRot = Quaternion.AngleAxis(180, transform.up);
        }
        //Change Camera
    }
}
