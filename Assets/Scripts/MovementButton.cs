using Pang;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pang
{
    /// <summary>
    /// This class represents a movement button used for controlling player movement on mobile devices.
    /// </summary>
    public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private MobileMovementButtonType mobileMovementButtonType;

        private bool isPressed;

        private void Update()
        {
            if (isPressed)
            {
                // Simulate continuous key press behavior
                HandleKeyPress();
            }
        }

        /// <summary>
        /// Handles the simulated continuous key press behavior based on the movement button type.
        /// </summary>
        private void HandleKeyPress()
        {
            if (mobileMovementButtonType == MobileMovementButtonType.Left)
                GameplayEvents.Instance.PlayerPressedMoveLeftButton?.Invoke();
            else if (mobileMovementButtonType == MobileMovementButtonType.Right)
                GameplayEvents.Instance.PlayerPressedMoveRightButton?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
        }

        private void OnDisable()
        {
            isPressed = false;
        }
    }

    /// <summary>
    /// Enum representing the type of movement button on mobile devices.
    /// </summary>
    public enum MobileMovementButtonType
    {
        Right,
        Left
    }
}

