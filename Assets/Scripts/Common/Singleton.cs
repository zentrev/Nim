using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;
    public bool isPersistant;

    public virtual void Awake()
    {
        if (isPersistant)
        {
            Debug.Log(Instance);
            if (Instance == null)
            {
                Instance = this as T;
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this as T;
        }
    }
}