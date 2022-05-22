using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] int barrierDamage = 1;

    [Header("Visuals")]
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject[] pieces;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.TryGetComponent(out PlayerController player))
    //    {
    //        player.HitObstacle(barrierDamage);
    //        Break();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.HitObstacle(barrierDamage);
            Break();
        }
    }

    private void Break()
    {
        GetComponent<Collider>().enabled = false;
        barrier.SetActive(false);
        foreach (var piece in pieces)
        {
            piece.SetActive(true);
            var rb = piece.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(5f, transform.position, 2f);
        }
        if (TryGetComponent(out LoopMovingObject loopMover))
        {
            loopMover.StopMovement();
        }

        Destroy(gameObject, 1.5f);
    }
}
