using UnityEngine;

public class Collectable : MonoBehaviour
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
        //particle
        GetComponentInChildren<Renderer>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
