using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem[] confetties;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController player))
        {
            player.Finish();
            foreach (var confetti in confetties)
            {
                confetti.Play();
            }
        }
    }
}
