using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is responsible for creating balls and injecting ball data to the ball controllers.
    /// </summary>
    [RequireComponent(typeof(BallControllerDataBinder))]
    public class BallMaker : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private Transform _ballsParent;

        private BallControllerDataBinder _ballControllerDataBinder;

        private void Awake()
        {
            _ballControllerDataBinder = GetComponent<BallControllerDataBinder>();
        }

        private void OnEnable()
        {
            GameplayEvents.Instance.PlayerCreated += CreateFirstBalls;
            GameplayEvents.Instance.BallHitProjectile += CreateSmallerBall;
        }

        private void OnDisable()
        {
            if (GameplayEvents.Instance == null) return;

            GameplayEvents.Instance.PlayerCreated -= CreateFirstBalls;
            GameplayEvents.Instance.BallHitProjectile -= CreateSmallerBall;
        }

        /// <summary>
        /// Creates the initial set of balls at the start of the game.
        /// </summary>
        private void CreateFirstBalls()
        {
            var mainCamera = Camera.main;

            float height = mainCamera.orthographicSize * 2;
            float width = height * mainCamera.aspect;

            float creationGap = width / LevelModelDataHolder.Instance.LevelModel.AmountOfStartingBalls;
            for (int i = 0; i < LevelModelDataHolder.Instance.LevelModel.AmountOfStartingBalls; i++)
            {
                CreateBall(0, new Vector2((-width / 4f) + (i * creationGap), 0), false);
            }
        }

        /// <summary>
        /// Creates a smaller ball when the ball hits a projectile.
        /// </summary>
        /// <param name="spawnPosition">The spawn position of the smaller ball.</param>
        /// <param name="ballLevel">The level of the ball.</param>
        private void CreateSmallerBall(Vector2 spawnPosition, int ballLevel)
        {
            ballLevel++;
            if (ballLevel >= LevelModelDataHolder.Instance.LevelModel.MaxBallLevel)
            {
                GameplayEvents.Instance.BallDestroyed?.Invoke();
                return;
            }
            CreateBall(ballLevel, spawnPosition, true);
            CreateBall(ballLevel, spawnPosition, false);
        }

        /// <summary>
        /// Creates a ball with the specified parameters.
        /// </summary>
        /// <param name="ballLevel">The level of the ball.</param>
        /// <param name="spawnPosition">The spawn position of the ball.</param>
        /// <param name="isMovingFirstRight">Flag indicating the initial movement direction of the ball.</param>
        private void CreateBall(int ballLevel, Vector2 spawnPosition, bool isMovingFirstRight)
        {
            List<BallController> ballControllers = new List<BallController>();

            // First, create the ball.
            GameObject ballObj = Instantiate(_ballPrefab, spawnPosition, Quaternion.identity);
            ballControllers.Add(ballObj.GetComponent<BallController>());
            ballObj.transform.SetParent(_ballsParent);

            // Then, inject the ball data to the ball controllers.
            Vector2 ballScale = Vector2.one * _ballControllerDataBinder.BallModel.LargestBallScale;
            for (int i = 0; i < ballLevel; i++)
            {
                ballScale /= _ballControllerDataBinder.BallModel.ScaleDownModifier;
            }
            _ballControllerDataBinder.InjectBallDataToControllers(ballControllers, ballScale, ballLevel, isMovingFirstRight);
        }
    }
}

