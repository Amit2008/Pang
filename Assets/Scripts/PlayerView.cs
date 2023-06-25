using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to set the player view.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView : MonoBehaviour
    {
        private SpriteRenderer _playerSpriteRenderer;

        /// <summary>
        /// The SpriteRenderer component of the player view.
        /// </summary>
        public SpriteRenderer PlayerViewRenderer => _playerSpriteRenderer;

        private void Awake()
        {
            // If the _playerSpriteRenderer is not assigned, get the SpriteRenderer component attached to the same GameObject.
            if (_playerSpriteRenderer == null)
                _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Sets the sprite of the player view.
        /// </summary>
        /// <param name="playerSprite">The sprite to set for the player view.</param>
        public void SetPlayerView(Sprite playerSprite)
        {
            _playerSpriteRenderer.sprite = playerSprite;
        }

        /// <summary>
        /// Moves the player by setting the position of the parent object.
        /// </summary>
        /// <param name="movementTranslation">The translation vector to move the player.</param>
        public void MovePlayer(Vector2 movementTranslation)
        {
            transform.parent.position = movementTranslation;
        }
    }
}

