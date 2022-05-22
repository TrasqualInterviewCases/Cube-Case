
public class SmallCollectable : Collectable
{
    protected override void PlayParticle()
    {
        ParticleManager.Instance.SpawnBlueParticle(transform.position + transform.up * 0.7f);
    }
}
