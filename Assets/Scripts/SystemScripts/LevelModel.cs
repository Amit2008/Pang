using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to store the level data.
    /// </summary>
    [CreateAssetMenu(fileName = "New Level", menuName = "Pang/Level/New Level")]
    public class LevelModel : ScriptableObject
    {
        [SerializeField] private string _levelName;
        [SerializeField, Range(1, 3)] private int _amountOfStartingBalls;
        [SerializeField, Range(1, 5)] private int _maxBallLevel;
        [SerializeField] private int _maxAmountOfBullets;

        /// <summary>
        /// The name of the level.
        /// </summary>
        public string LevelName => _levelName;

        /// <summary>
        /// The number of balls the player starts with in this level.
        /// </summary>
        public int AmountOfStartingBalls => _amountOfStartingBalls;

        /// <summary>
        /// The maximum level that a ball can reach in this level.
        /// </summary>
        public int MaxBallLevel => _maxBallLevel;

        /// <summary>
        /// The maximum amount of bullets that the player can have in this level.
        /// </summary>
        public int MaxAmountOfBullets => _maxAmountOfBullets;
    }
}

