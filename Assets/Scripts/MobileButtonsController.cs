using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to set the activation state of mobile buttons based on the platform.
    /// </summary>
    public class MobileButtonsController : MonoBehaviour
    {
        private void Awake()
        {
            SetMobileButtonsActivationState();
        }

        /// <summary>
        /// Sets the activation state of mobile buttons based on the platform.
        /// </summary>
        private void SetMobileButtonsActivationState()
        {
#if !UNITY_ANDROID
            gameObject.SetActive(false);
#endif
        }
    }
}

