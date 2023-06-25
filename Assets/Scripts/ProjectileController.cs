using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is the controller of the projectile and it contains the logic of the projectile.
    /// </summary>
    [RequireComponent(typeof(ProjectileView), typeof(Rigidbody2D))]
    public class ProjectileController : MonoBehaviour
    {
        private ProjectileView _projectileView;
        private Rigidbody2D _rBody;
        private ProjectileModel _projectileModel;

        private void Awake()
        {
            // Get the ProjectileView and Rigidbody2D components attached to the same GameObject.
            _projectileView = GetComponent<ProjectileView>();
            _rBody = GetComponent<Rigidbody2D>();
        }

        private IEnumerator Start()
        {
            // Wait until the projectile model is set before setting the projectile velocity.
            yield return new WaitUntil(() => _projectileModel != null);
            SetProjectileVelocity();
        }

        /// <summary>
        /// Sets the data of the projectile using the provided projectile model.
        /// </summary>
        /// <param name="projectileModel">The projectile model containing the data of the projectile.</param>
        public void SetProjectileData(ProjectileModel projectileModel)
        {
            _projectileModel = projectileModel;
            SetProjectileView();
        }

        private void SetProjectileView()
        {
            // Set the visual representation of the projectile using the projectile sprite from the projectile model.
            _projectileView.SetProjectileView(_projectileModel.ProjectileSprite);
        }

        private void SetProjectileVelocity()
        {
            // Set the velocity of the projectile based on the projectile speed from the projectile model.
            _rBody.velocity = Vector2.up * _projectileModel.ProjectileSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            BallController ballController = collision.gameObject.GetComponent<BallController>();
            WallController wallController = collision.gameObject.GetComponent<WallController>();

            // Check if the collision is with a ball or a wall, and destroy the projectile if it is.
            if (ballController != null || wallController != null)
            {
                DestroyProjectile();
            }
        }

        private void DestroyProjectile()
        {
            // Raise the event that the projectile has been destroyed.
            GameplayEvents.Instance.ProjectileDestroyed?.Invoke();

            // Destroy the projectile GameObject.
            Destroy(gameObject);
        }
    }
}

