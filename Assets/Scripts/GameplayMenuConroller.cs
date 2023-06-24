using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to control the gamplay menu
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

        private void SetPopup(bool isWin)         
        {
            _popup.SetActive(true);
            _gameplayMenuView.SetView(isWin ? GameConstants.GameWon : GameConstants.GameLost);
        }

        public void GoToMainMenu() 
        {
            GeneralEvents.Instance.GoToMainSceneEventRaised?.Invoke(gameObject.scene.name);
            Time.timeScale = 1f;
        }
        public void RestartGame() 
        {
            GameplayEvents.Instance.ResetGameplaySceneClicked?.Invoke();
            Time.timeScale = 1f;
            _popup.SetActive(false);
        }
    }
}
