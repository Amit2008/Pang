using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to bind the level button controllers to the level button maker.
    /// </summary>
    public class LevelButtonControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private LevelModel[] _levelModels;

        /// <summary>
        /// Gets the amount of levels.
        /// </summary>
        public int AmountOfLevels => _levelModels.Length;

        /// <summary>
        /// Injects the LevelButtonControllers with the corresponding LevelModels.
        /// </summary>
        /// <param name="levelButtonControllers">The list of LevelButtonControllers to inject.</param>
        public void InjectLevelButtonControllers(List<LevelButtonController> levelButtonControllers)
        {
            // If the count of LevelButtonControllers does not match the count of LevelModels, return.
            if (levelButtonControllers.Count != _levelModels.Length) return;

            // Iterate through the LevelButtonControllers and inject the corresponding LevelModel.
            for (int i = 0; i < levelButtonControllers.Count; i++)
            {
                levelButtonControllers[i].InjectLevelButtonController(_levelModels[i]);
            }
        }
    }
}

