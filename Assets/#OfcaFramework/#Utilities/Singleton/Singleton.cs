using UnityEngine;

namespace OfcaFramework
{
    namespace CodePatterns
    {
        public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
        {
            public static T Instance { get; private set; }
            protected virtual void Awake() => Instance = this as T;

            protected virtual void OnApplicationQuit()
            {
                Instance = null;
                Destroy(gameObject);
            }
        }
        /// <summary>
        /// public class ExampleClass : Singleton<ExampleClass>
        /// </summary>
        public class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
        {
            protected override void Awake()
            {
                if (Instance != null)
                {
                    Destroy(gameObject);
                }
                base.Awake();
            }
        }

        /// <summary>
        /// public class ExampleClass : PersistentSingleton<ExampleClass>
        /// </summary>

        public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
        {
            protected override void Awake()
            {
                base.Awake();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}