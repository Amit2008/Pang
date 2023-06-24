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

        public int AmountOfLevels => _levelModels.Length;
        public void InjectLevelButtonControllers(List<LevelButtonController> levelButtonControllers) 
        {
            if (levelButtonControllers.Count != _levelModels.Length) return;

            for (int i = 0; i < levelButtonControllers.Count; i++)
            {
                levelButtonControllers[i].InjectLevelButtonController(_levelModels[i]);
            }
        }

    }
}
