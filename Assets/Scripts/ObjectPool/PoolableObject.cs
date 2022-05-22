using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolable
{
    [SerializeField] PoolableObjectType objectType;

    PoolableObjectType IPoolable.GetType()
    {
        return objectType;
    }
}
