using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is responsible for resetting the gameplay scene and starting the level again.
    /// </summary>
    public class GameplaySceneReset : MonoBehaviour
    {
        [SerializeField] private Transform[] objectContainers;

        private void OnEnable()
        {
            GameplayEvents.Instance.ResetGameplaySceneClicked += ResetLevelAndStartAgain;
        }

        private void OnDisable()
        {
            GameplayEvents.Instance.ResetGameplaySceneClicked -= ResetLevelAndStartAgain;
        }

        /// <summary>
        /// Resets the level by destroying all objects within the specified object containers and invokes the game scene reset event.
        /// </summary>
        private void ResetLevelAndStartAgain()
        {
            foreach (var objectContainer in objectContainers)
            {
                foreach (Transform child in objectContainer)
                {
                    Destroy(child.gameObject);
                }
            }
            GameplayEvents.Instance.GameSceneReset?.Invoke();
        }
    }
}

