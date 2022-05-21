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
}
