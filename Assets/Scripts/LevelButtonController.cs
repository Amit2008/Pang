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
            // Get the LevelButtonView component attached to the same GameObject.
            _levelButtonView = GetComponent<LevelButtonView>();
        }

        /// <summary>
        /// Injects the LevelModel to the LevelButtonController and sets the LevelButtonView.
        /// </summary>
        /// <param name="levelModel">The LevelModel containing the data of the level.</param>
        public void InjectLevelButtonController(LevelModel levelModel)
        {
            _levelModel = levelModel;

            // Set the LevelButtonView using the level name from the LevelModel and provide a callback for the button click event.
            _levelButtonView.SetLevelButtonView(levelModel.LevelName, OnLevelButtonClick);
        }

        private void OnLevelButtonClick()
        {
            // Raise the event that the level button has been clicked and pass the associated LevelModel.
            GeneralEvents.Instance.LevelButtonClicked?.Invoke(_levelModel);
        }
    }
}

