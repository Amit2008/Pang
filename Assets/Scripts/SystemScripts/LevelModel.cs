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
        [SerializeField, Range(1,3)] private int _amountOfStartingBalls;
        [SerializeField, Range(1, 5)] private int _maxBallLevel;
        [SerializeField] private int _maxAmountOfBullets;

        public string LevelName => _levelName;
        public int AmountOfStartingBalls => _amountOfStartingBalls;
        public int MaxBallLevel => _maxBallLevel;
        public int MaxAmountOfBullets => _maxAmountOfBullets;
    }
}
