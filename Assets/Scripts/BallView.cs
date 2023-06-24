using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to set the ball's view.
    /// </summary>
    public class BallView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _ballSpriteRenderer;

        public SpriteRenderer BallRenderer => _ballSpriteRenderer;

        public void SetBallView(Sprite ballSprite, Vector2 ballScale) 
        {
            _ballSpriteRenderer.sprite = ballSprite;
            transform.localScale = Vector2.one * ballScale;
        }

        public void SetBallPosition(Vector2 newPosition) 
        {
            transform.position = newPosition;
        }
    }
}
