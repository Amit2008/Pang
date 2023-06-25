using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is responsible for controlling the gameplay menu and its interactions.
    /// </summary>
    [RequireComponent(typeof(GameplayMenuView))]
    public class GameplayMenuConroller : MonoBehaviour
    {
        [SerializeField] private GameObject _popup;
        private GameplayMenuView _gameplayMenuView;

        private void Awake()
        {
            _gameplayMenuView = GetComponent<GameplayMenuView>();
        }

        private void OnEnable()
        {
            GameplayEvents.Instance.GameEnded += SetPopup;
        }
        private void OnDisable()
        {
            GameplayEvents.Instance.GameEnded -= SetPopup;
        }

        /// <summary>
        /// Sets the popup state and updates the gameplay menu view with the appropriate title.
        /// </summary>
        /// <param name="isWin">A flag indicating if the game ended with a win.</param>
        private void SetPopup(bool isWin)
        {
            _popup.SetActive(true);
            _gameplayMenuView.SetView(isWin ? GameConstants.GameWon : GameConstants.GameLost);
        }

        /// <summary>
        /// Transitions to the main menu scene.
        /// </summary>
        public void GoToMainMenu()
        {
            GeneralEvents.Instance.GoToMainSceneEventRaised?.Invoke(gameObject.scene.name);
            Time.timeScale = 1f;
        }

        /// <summary>
        /// Restarts the gameplay scene.
        /// </summary>
        public void RestartGame()
        {
            GameplayEvents.Instance.ResetGameplaySceneClicked?.Invoke();
            Time.timeScale = 1f;
            _popup.SetActive(false);
        }
    }
}

