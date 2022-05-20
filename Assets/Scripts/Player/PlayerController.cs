using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void HitObstacle()
    {
        movement.ApplyHitMotion();
        StartCoroutine(HitObstacleCo());
    }

    IEnumerator HitObstacleCo()
    {
        yield return new WaitForSeconds(1.25f);
        movement.StopHitMotion();
    }
}
