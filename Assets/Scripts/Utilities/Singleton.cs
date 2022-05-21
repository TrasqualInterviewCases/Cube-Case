using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance != null)
            {
                Destroy(instance.gameObject);
            }
            instance = FindObjectOfType<T>();
            return instance;
        }
    }
}
