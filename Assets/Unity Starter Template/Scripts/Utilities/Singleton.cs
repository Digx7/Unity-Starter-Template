using UnityEngine;

namespace Digx7.Zygote
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected bool isSafeInstance = false;

        public virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Another Singleton " + Instance + " was found so deleting this one");
                Destroy(this.gameObject);
                return;
            }
            else
            {
                isSafeInstance = true;
                SafeAwake();
                DontDestroyOnLoad(this);

                Instance = this as T;
            }
        }

        // Only called if this singleton is the valid Instance
        // Allows us to use Awake() in its normal call order without dealing with the edge case of multiple Instances existing at once.
        public virtual void SafeAwake()
        {
            
        }
    }
}
