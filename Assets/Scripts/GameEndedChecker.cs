using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is responsible for checking the game ending conditions and notifying the gameplay events accordingly.
    /// </summary>
    public class GameEndedChecker : MonoBehaviour
    {
        [SerializeField] private Transform _ballContainer;

        private void OnEnable()
        {
            GameplayEvents.Instance.BallDestroyed += CheckGameWin;
            GameplayEvents.Instance.BallHitPlayer += GameLost;
        }

        private void OnDisable()
        {
            GameplayEvents.Instance.BallDestroyed -= CheckGameWin;
            GameplayEvents.Instance.BallHitPlayer -= GameLost;
        }

        /// <summary>
        /// Checks for game win condition after a ball is destroyed.
        /// </summary>
        private void CheckGameWin()
        {
            StartCoroutine(CheckGameWinAtEndOfFrame());
        }

        /// <summary>
        /// Coroutine to check for game win condition at the end of the frame.
        /// </summary>
        private IEnumerator CheckGameWinAtEndOfFrame()
        {
            yield return null;

            // After the ball has been destroyed, check if there are any balls left in the scene
            if (_ballContainer.childCount == 0)
            {
                // If there are no balls left in the scene, the player has won the game
                GameEnded(true);
            }
        }

        /// <summary>
        /// Handles the game loss condition when a ball hits the player.
        /// </summary>
        private void GameLost()
        {
            GameEnded(false);
        }

        /// <summary>
        /// Notifies the gameplay events that the game has ended with the specified outcome.
        /// </summary>
        /// <param name="isWin">A flag indicating if the game ended with a win.</param>
        private void GameEnded(bool isWin)
        {
            GameplayEvents.Instance.GameEnded?.Invoke(isWin);
            Time.timeScale = 0f;
        }
    }
}

