using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to control the player and set the view.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawner;
        [SerializeField] private PlayerView _playerView;

        private PlayerModel _playerModel;

        private bool _isMovingLeft;
        private bool _isMovingRight;
        private bool _isShooting;

        private void OnEnable()
        {
            // Subscribe to input events
            GameplayEvents.Instance.PlayerPressedMoveLeftButton += MoveLeft;
            GameplayEvents.Instance.PlayerPressedMoveRightButton += MoveRight;
            GameplayEvents.Instance.PlayerReleasedMovementButton += StopMovement;
            GameplayEvents.Instance.PlayerPressedShootingKey += PlayerIsShooting;
        }

        private void OnDisable()
        {
            // Unsubscribe from input events
            if (GameplayEvents.Instance == null) return;

            GameplayEvents.Instance.PlayerPressedMoveLeftButton -= MoveLeft;
            GameplayEvents.Instance.PlayerPressedMoveRightButton -= MoveRight;
            GameplayEvents.Instance.PlayerReleasedMovementButton -= StopMovement;
            GameplayEvents.Instance.PlayerPressedShootingKey -= PlayerIsShooting;
        }

        private void Update()
        {
            HandleMovement();
            HandleShooting();
        }

        private void MoveLeft()
        {
            _isMovingLeft = true;
            _isMovingRight = false;
        }

        private void MoveRight()
        {
            _isMovingRight = true;
            _isMovingLeft = false;
        }

        private void StopMovement()
        {
            _isMovingRight = false;
            _isMovingLeft = false;
        }

        private void PlayerIsShooting()
        {
            _isShooting = true;
        }

        public void SetPlayerModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerView.SetPlayerView(playerModel.PlayerSprite);
        }

        private void HandleMovement()
        {
            // Handle desktop movement controls
            float moveInput = 0;
            float minX, maxX;

            var mainCamera = Camera.main;
            float height = mainCamera.orthographicSize * 2;
            float width = height * mainCamera.aspect;

            minX = -(width / 2f);
            maxX = (width / 2f);

            if (Input.GetKey(_playerModel.MoveLeftKeyCode))
            {
                _isMovingLeft = true;
                _isMovingRight = false;
            }
            else if (Input.GetKey(_playerModel.MoveRightKeyCode))
            {
                _isMovingRight = true;
                _isMovingLeft = false;
            }

            // Handle mobile movement controls
            if (_isMovingLeft)
            {
                moveInput = -1f;
            }
            else if (_isMovingRight)
            {
                moveInput = 1f;
            }

            // Multiply moveSpeed by Time.deltaTime to make the movement frame-rate independent
            var movementTranslation = Vector2.right * moveInput * _playerModel.MoveSpeed * Time.deltaTime;

            // Calculate the player's new position
            Vector2 newPosition = new Vector2(transform.position.x + movementTranslation.x, transform.position.y);

            // Clamp the player's position to the screen boundaries
            float offset = (_playerView.PlayerViewRenderer.size.x / 2f) * _playerView.transform.localScale.x;
            newPosition.x = Mathf.Clamp(newPosition.x, minX + offset, maxX - offset);

            _playerView.MovePlayer(newPosition);

            _isMovingLeft = false;
            _isMovingRight = false;
        }

        private void HandleShooting()
        {
            if (Input.GetKeyDown(_playerModel.ShootKeyCode) || _isShooting)
            {
                // Invoke event to attempt shooting
                GameplayEvents.Instance.PlayerAttemptedShooting?.Invoke(_projectileSpawner);

                _isShooting = false;
                Debug.Log("HandleShooting: Player tries to shoot projectile");
            }
        }
    }
}
