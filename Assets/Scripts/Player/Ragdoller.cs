using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    Rigidbody[] rbs;
    Collider[] cols;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        cols = GetComponentsInChildren<Collider>();
    }

    private void ActivateRagdoll()
    {
        foreach (var rb in rbs)
        {
            rb.isKinematic = false;
        }

        foreach (var col in cols)
        {
            col.enabled = true;
        }

        rbs[0].isKinematic = true;
        cols[0].enabled = false;
    }

    private void OnEnable()
    {
        PlayerHealthManager.OnPlayerDeath += ActivateRagdoll;
    }

    private void OnDisable()
    {
        PlayerHealthManager.OnPlayerDeath -= ActivateRagdoll;
    }
}
