using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to inject the player data to the player controllers.
    /// </summary>
    public class PlayerControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private PlayerModel _playerModel;

        /// <summary>
        /// Injects the player data to the specified list of player controllers.
        /// </summary>
        /// <param name="playerControllers">The list of player controllers to inject the data into.</param>
        public void InjectPlayerDataToControllers(List<PlayerController> playerControllers)
        {
            // Iterate through the list of player controllers and set the player model.
            foreach (var playerController in playerControllers)
            {
                playerController.SetPlayerModel(_playerModel);
            }
        }
    }
}

