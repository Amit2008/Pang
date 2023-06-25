using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is responsible for controlling the ball's behavior and managing its view.
    /// </summary>
    [RequireComponent(typeof(BallView), typeof(CircleCollider2D))]
    public class BallController : MonoBehaviour
    {
        private BallModel _ballModel;
        private BallView _ballView;
        private int _ballLevel;
        private Rigidbody2D _rBody;
        private float _forceY;
        private float _forceX;
        private bool _isMovingRight = true;

        private void Awake()
        {
            _ballView = GetComponent<BallView>();
            _rBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SetBallForces();
        }

        private void Update()
        {
            MoveBallHorizontally();
        }

        private void MoveBallHorizontally()
        {
            Vector2 newPosition = _isMovingRight ?
                new Vector2(transform.position.x + _forceX * Time.deltaTime, transform.position.y) :
                new Vector2(transform.position.x - _forceX * Time.deltaTime, transform.position.y);
            _ballView.SetBallPosition(newPosition);
        }

        /// <summary>
        /// Injects the ball's data and updates its visual representation.
        /// </summary>
        /// <param name="ballModel">The data model for the ball.</param>
        /// <param name="ballScale">The scale of the ball.</param>
        /// <param name="ballLevel">The level of the ball.</param>
        /// <param name="isMovingFirstRight">Flag indicating the initial movement direction.</param>
        public void InjectBallData(BallModel ballModel, Vector2 ballScale, int ballLevel, bool isMovingFirstRight)
        {
            _ballModel = ballModel;
            _ballView.SetBallView(_ballModel.BallSprite, ballScale);
            _ballLevel = ballLevel;
            _isMovingRight = isMovingFirstRight;
        }

        private void SetBallForces()
        {
            _forceY = _ballModel.LargestBallForceY;
            _forceX = _ballModel.ForceX;

            for (int i = 0; i < _ballLevel; i++)
            {
                _forceY -= _ballModel.ForceReductionAmount;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            WallController wallController = collision.gameObject.GetComponent<WallController>();
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            ProjectileController projectileController = collision.gameObject.GetComponent<ProjectileController>();

            if (wallController != null)
            {
                var wallType = wallController.WallType;
                SetBallVelocity(wallType);
            }
            else if (playerController != null)
            {
                GameplayEvents.Instance.BallHitPlayer?.Invoke();
                Debug.Log("Ball Hit Player");
            }
            else if (projectileController != null)
            {
                GameplayEvents.Instance.BallHitProjectile?.Invoke(transform.position, _ballLevel);
                Debug.Log("Ball Hit Projectile");

                DestroyBall();
            }
        }

        private void SetBallVelocity(WallType wallType)
        {
            switch (wallType)
            {
                case WallType.Bottom:
                    SetBallVelocity(new Vector2(0, _forceY));
                    break;
                case WallType.Left:
                    _isMovingRight = true;
                    break;
                case WallType.Right:
                    _isMovingRight = false;
                    break;
                default:
                    break;
            }
        }

        private void SetBallVelocity(Vector2 velocity)
        {
            _rBody.velocity = velocity;
        }

        private void DestroyBall()
        {
            Destroy(gameObject);
        }
    }
}

