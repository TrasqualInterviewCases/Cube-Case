using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCollectableHandler collector))
        {
            collector.Collect(amount);
            PlayCollectionAnim();
        }
    }

    private void PlayCollectionAnim()
    {
        PlayParticle();
        GetComponentInChildren<Renderer>().enabled = false;
        Destroy(gameObject, 2f);
    }

    protected abstract void PlayParticle();
}
