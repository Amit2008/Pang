using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class contains the data of the ball.
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

        public Sprite BallSprite => _ballSprite;
        public float LargestBallScale => _largestBallScale;
        public float ScaleDownModifier => _scaleDownModifier;
        public float ForceX => _forceX;
        public float LargestBallForceY => _largestForceY;
        public float ForceReductionAmount => _forceYReductionAmount;
    }
}
