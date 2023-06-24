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
        public static LevelModelDataHolder Instance { get; private set; }
        private LevelModel _levelModel;

        public LevelModel LevelModel => _levelModel;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else 
            {
                Debug.LogError("LevelModelDataHolder: More then one instance of the class LevelModelDataHolder - error");
                Destroy(gameObject);
            }
        }
        private void OnEnable()
        {
            GeneralEvents.Instance.LevelButtonClicked += SaveCurrentLevelModel;
        }
        private void OnDisable()
        {
            GeneralEvents.Instance.LevelButtonClicked -= SaveCurrentLevelModel;
        }

        private void SaveCurrentLevelModel(LevelModel levelModel)
        {
            _levelModel = levelModel;
            GeneralEvents.Instance.LevelReadyToBeLoaded?.Invoke();
        }
    }
}
