using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
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

        private void CheckGameWin() 
        {
            StartCoroutine(CheckGameWinAtEndOfFrame());
        }
        private IEnumerator CheckGameWinAtEndOfFrame()
        {
            yield return null;
            //After the ball has been destroyed check if there are any balls left in the scene
            if (_ballContainer.childCount == 0)
            {
                // If there are no balls left in the scene, the player has won the game
                GameEnded(true);
            }
        }
        private void GameLost() 
        {
            GameEnded(false);
        }

        private void GameEnded(bool isWin) 
        {
            GameplayEvents.Instance.GameEnded?.Invoke(isWin);
            Time.timeScale = 0f;
        }
    }
}
