using System.Collections;
using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    [SerializeField] ParticleSystem yellowParticle;
    [SerializeField] ParticleSystem blueParticle;
    [SerializeField] ParticleSystem hitParticle;

    public void SpawnYellowParticle(Vector3 pos)
    {
        var particle = ObjectPooler.Instance.SpawnFromPool(PoolableObjectType.YellowParticle, pos, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DespawnParticle(particle));
    }

    public void SpawnBlueParticle(Vector3 pos)
    {
        var particle = ObjectPooler.Instance.SpawnFromPool(PoolableObjectType.BlueParticle, pos, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DespawnParticle(particle));
    }

    public void SpawnHitParticle(Vector3 pos)
    {
        var particle = ObjectPooler.Instance.SpawnFromPool(PoolableObjectType.HitParticle, pos, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DespawnParticle(particle));
    }

    private IEnumerator DespawnParticle(GameObject particle)
    {
        yield return new WaitForSeconds(1.5f);
        particle.GetComponent<ParticleSystem>().Stop();
        ObjectPooler.Instance.RequeuePiece(particle);
    }
}
