using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to control the player's shooting if the game is played on mobile.
    /// </summary>
    public class ShootingButton : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GameplayEvents.Instance.PlayerPressedShootingKey?.Invoke();
        }
    }
}
