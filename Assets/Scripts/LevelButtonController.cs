using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to control the level button.
    /// </summary>
    [RequireComponent(typeof(LevelButtonView))]
    public class LevelButtonController : MonoBehaviour 
    {
        private LevelButtonView _levelButtonView;
        private LevelModel _levelModel;

        private void Awake()
        {
            _levelButtonView = GetComponent<LevelButtonView>();
        }
        public void InjectLevelButtonController(LevelModel levelModel)
        {
            _levelModel = levelModel;
            _levelButtonView.SetLevelButtonView(levelModel.LevelName, OnLevelButtonClick);
        }

        private void OnLevelButtonClick()
        {
            GeneralEvents.Instance.LevelButtonClicked?.Invoke(_levelModel); 
        }
    }
}
