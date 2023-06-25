using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is responsible for setting the ball's view.
    /// </summary>
    public class BallView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _ballSpriteRenderer;

        /// <summary>
        /// Sets the ball's view by updating the sprite and scale.
        /// </summary>
        /// <param name="ballSprite">The sprite to be assigned to the ball.</param>
        /// <param name="ballScale">The scale of the ball.</param>
        public void SetBallView(Sprite ballSprite, Vector2 ballScale)
        {
            _ballSpriteRenderer.sprite = ballSprite;
            transform.localScale = Vector2.one * ballScale;
        }

        /// <summary>
        /// Sets the position of the ball.
        /// </summary>
        /// <param name="newPosition">The new position of the ball.</param>
        public void SetBallPosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}

