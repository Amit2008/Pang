using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to create a singelton of a monobehaviour class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DefaultExecutionOrder(-50)]
    public class MonoSingelton<T> : MonoBehaviour where T : MonoSingelton<T>
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
                Debug.LogError($"MonoSingelton: More then one instance of the class {typeof(T)} - error");
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            
        }
    }
}
