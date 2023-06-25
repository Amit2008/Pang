using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to hold the level model data.
    /// </summary>
    public class LevelModelDataHolder : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance of the LevelModelDataHolder.
        /// </summary>
        public static LevelModelDataHolder Instance { get; private set; }

        private LevelModel _levelModel;

        /// <summary>
        /// The currently stored level model.
        /// </summary>
        public LevelModel LevelModel => _levelModel;

        private void Awake()
        {
            // Create the singleton instance or destroy the duplicate instance.
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("LevelModelDataHolder: More than one instance of the class LevelModelDataHolder - error");
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            // Subscribe to the LevelButtonClicked event.
            GeneralEvents.Instance.LevelButtonClicked += SaveCurrentLevelModel;
        }

        private void OnDisable()
        {
            // Unsubscribe from the LevelButtonClicked event.
            GeneralEvents.Instance.LevelButtonClicked -= SaveCurrentLevelModel;
        }

        /// <summary>
        /// Saves the selected level model and triggers the LevelReadyToBeLoaded event.
        /// </summary>
        /// <param name="levelModel">The level model to be saved.</param>
        private void SaveCurrentLevelModel(LevelModel levelModel)
        {
            _levelModel = levelModel;
            GeneralEvents.Instance.LevelReadyToBeLoaded?.Invoke();
        }
    }
}

