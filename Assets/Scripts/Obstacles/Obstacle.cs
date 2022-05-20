using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController player))
        {
            player.HitObstacle();
        }
    }
}
