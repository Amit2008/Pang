using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField] Button[] _buttons;

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

        private void SetButtonInteractivityState(bool state) 
        {
            foreach (var button in _buttons)
            {
                button.interactable = state;
            }
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
            SetButtonInteractivityState(false);
        }

        /// <summary>
        /// Restarts the gameplay scene.
        /// </summary>
        public void RestartGame()
        {
            GameplayEvents.Instance.ResetGameplaySceneClicked?.Invoke();
            SetButtonInteractivityState(true);
            _popup.SetActive(false);
        }
    }
}

