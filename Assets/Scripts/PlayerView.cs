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

        public SpriteRenderer PlayerViewRenderer => _playerSpriteRenderer;

        private void Awake()
        {
            if(_playerSpriteRenderer == null)
                _playerSpriteRenderer = GetComponent<SpriteRenderer>();            
        }

        public void SetPlayerView(Sprite playerSprite) 
        {            
            _playerSpriteRenderer.sprite = playerSprite;
        }

        public void MovePlayer(Vector2 movementTranslation) 
        {
            transform.parent.position = movementTranslation;
        }
    }
}
