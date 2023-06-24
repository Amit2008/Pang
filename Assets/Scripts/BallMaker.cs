using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to create balls and inject the ball data to the ball controllers.
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

        private void CreateFirstBalls() 
        {
            var mainCamera = Camera.main;
            
            float height = mainCamera.orthographicSize * 2;
            float width = height * mainCamera.aspect;

            float creationGap = width / LevelModelDataHolder.Instance.LevelModel.AmountOfStartingBalls;
            for (int i = 0; i < LevelModelDataHolder.Instance.LevelModel.AmountOfStartingBalls; i++)
            {
                CreateBall(0, new Vector2((-width / 4f) + (i* creationGap), 0), false);
            }
        }

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

        private void CreateBall(int ballLevel, Vector2 spawnPosition, bool isMovingFirstRight) 
        {
            List<BallController> ballControllers = new List<BallController>();

            // First Create the ball.
            GameObject ballObj = Instantiate(_ballPrefab, spawnPosition, Quaternion.identity);
            ballControllers.Add(ballObj.GetComponent<BallController>());
            ballObj.transform.SetParent(_ballsParent);

            //Then, inject the ball data to the ball controllers
            Vector2 ballScale = Vector2.one * _ballControllerDataBinder.BallModel.LargestBallScale;
            for (int i = 0; i < ballLevel; i++)
            {
                ballScale /= _ballControllerDataBinder.BallModel.ScaleDownModifier;
            }
            _ballControllerDataBinder.InjectBallDataToControllers(ballControllers, ballScale, ballLevel, isMovingFirstRight);
        }
    }
}
