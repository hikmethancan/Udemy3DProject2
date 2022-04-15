using UnityEngine;

namespace UdemyProject2.Utilities
{
    public abstract class SingletonObjects<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void SingletonObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}