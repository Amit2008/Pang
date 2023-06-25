using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class represents the data of a ball in the game, including its visual representation and various configurations.
    /// </summary>
    [CreateAssetMenu(fileName = "New Ball Configuration", menuName = "Pang/Level/Bubble")]
    public class BallModel : ScriptableObject
    {
        [Header("Views")]
        [SerializeField] private Sprite _ballSprite;

        [Header("Scale Configurations")]
        [SerializeField] private float _largestBallScale;
        [SerializeField] private float _scaleDownModifier;

        [Header("Force Configurations")]
        [SerializeField] private float _forceX = 2.5f;
        [SerializeField] private float _largestForceY = 12f;
        [SerializeField] private float _forceYReductionAmount = 1.75f;

        /// <summary>
        /// The sprite representing the ball's visual appearance.
        /// </summary>
        public Sprite BallSprite => _ballSprite;

        /// <summary>
        /// The largest scale value for the ball.
        /// </summary>
        public float LargestBallScale => _largestBallScale;

        /// <summary>
        /// The scale modifier applied when the ball shrinks.
        /// </summary>
        public float ScaleDownModifier => _scaleDownModifier;

        /// <summary>
        /// The horizontal force applied to the ball when it is launched.
        /// </summary>
        public float ForceX => _forceX;

        /// <summary>
        /// The largest vertical force applied to the ball when it is launched.
        /// </summary>
        public float LargestBallForceY => _largestForceY;

        /// <summary>
        /// The amount by which the vertical force is reduced when the ball bounces or collides.
        /// </summary>
        public float ForceReductionAmount => _forceYReductionAmount;
    }
}

