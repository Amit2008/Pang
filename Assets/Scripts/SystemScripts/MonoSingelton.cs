using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to create a singleton instance of a MonoBehaviour class.
    /// </summary>
    /// <typeparam name="T">The type of the singleton class.</typeparam>
    [DefaultExecutionOrder(-50)]
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
            }
            else
            {
                Debug.LogError($"MonoSingleton: More than one instance of the class {typeof(T)} - error");
                Destroy(gameObject);
            }
        }
    }
}

