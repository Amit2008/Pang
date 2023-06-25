using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class Listens to the LevelButton being clicked and set the interaction state of the buttons.
    /// </summary>
    public class LevelButtonGroupConroller : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        private void OnEnable()
        {
            GeneralEvents.Instance.LevelButtonClicked += SetInteractionState;
        }
        private void OnDisable()
        {
            GeneralEvents.Instance.LevelButtonClicked -= SetInteractionState;
        }

        private void SetInteractionState(LevelModel _) 
        {
            canvasGroup.blocksRaycasts = false;
        }
    }
}
