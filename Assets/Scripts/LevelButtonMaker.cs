using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to make the level buttons.
    /// </summary>
    [RequireComponent(typeof(LevelButtonControllerDataBinder))]
    public class LevelButtonMaker : MonoBehaviour
    {
        [SerializeField] private GameObject _levelButtonPrefab;
        [SerializeField] private Transform _container;
        private LevelButtonControllerDataBinder _dataBinder;

        private void Awake()
        {
            _dataBinder = GetComponent<LevelButtonControllerDataBinder>();
        }

        private void Start()
        {
            CreateLevelButtons();
        }

        private void CreateLevelButtons() 
        {
            List<LevelButtonController> levelButtonControllers = new List<LevelButtonController>();

            for (int i = 0; i < _dataBinder.AmountOfLevels; i++)
            {
                GameObject levelButton = Instantiate(_levelButtonPrefab, _container);
                levelButtonControllers.Add(levelButton.GetComponent<LevelButtonController>());
            }

            _dataBinder.InjectLevelButtonControllers(levelButtonControllers);
        }
    }
}
