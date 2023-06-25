using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pang
{
    /// <summary>
    /// This script is used to control the player's shooting if the game is played on mobile.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ShootingButton : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Shoot);
        }

        /// <summary>
        /// Triggers the shooting event when the shooting button is pressed.
        /// </summary>
        private void Shoot()
        {
            GameplayEvents.Instance.PlayerPressedShootingKey?.Invoke();
        }
    }
}
