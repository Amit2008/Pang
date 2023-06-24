using Pang;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pang
{
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

        private void HandleKeyPress()
        {
            if(mobileMovementButtonType == MobileMovementButtonType.Left) GameplayEvents.Instance.PlayerPressedMoveLeftButton?.Invoke();
            else if(mobileMovementButtonType == MobileMovementButtonType.Right) GameplayEvents.Instance.PlayerPressedMoveRightButton?.Invoke();
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
    public enum MobileMovementButtonType
    {
        Right,
        Left
    }
}
