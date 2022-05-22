using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCollectable : Collectable
{
    protected override void PlayParticle()
    {
        ParticleManager.Instance.SpawnYellowParticle(transform.position + transform.up * 0.7f);
    }
}
