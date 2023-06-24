using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to control the player if the game is played on mobile.
    /// </summary>
    public class MovementButton : MonoBehaviour
    {
        [SerializeField] private MobileMovementButtonType mobileMovementButtonType;

        private void OnMouseOver()
        {
            if (!Input.GetKey(KeyCode.Mouse0)) return;

            if (mobileMovementButtonType == MobileMovementButtonType.Right)
            {
                GameplayEvents.Instance.PlayerPressedMoveRightButton?.Invoke();
            }
            else if(mobileMovementButtonType == MobileMovementButtonType.Left)
            {
                GameplayEvents.Instance.PlayerPressedMoveLeftButton?.Invoke();
            }
        }

        private void OnMouseExit()
        {
            GameplayEvents.Instance.PlayerReleasedMovementButton?.Invoke();
        }
    }

    public enum MobileMovementButtonType 
    {
        Right,
        Left
    }
}
