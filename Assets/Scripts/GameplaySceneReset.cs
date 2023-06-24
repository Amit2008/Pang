using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
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
