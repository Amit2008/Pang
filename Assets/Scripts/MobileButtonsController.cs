using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to set the mobile buttons activation state.
    /// </summary>
    public class MobileButtonsController : MonoBehaviour
    {
        private void Awake()
        {
            SetMobileButtonsActivationState();
        }

        private void SetMobileButtonsActivationState() 
        {
#if !UNITY_ANDROID
            gameObject.SetActive(false);
#endif
        }
    }
}
