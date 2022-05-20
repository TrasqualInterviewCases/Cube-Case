using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject[] pieces;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController player))
        {
            player.HitObstacle();
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
    }
}
