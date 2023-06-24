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
            _projectileView = GetComponent<ProjectileView>();
            _rBody = GetComponent<Rigidbody2D>();
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => _projectileModel != null);
            SetProjectileVelocity();
        }

        public void SetProjectileData(ProjectileModel projectileModel) 
        {
            _projectileModel = projectileModel;
            SetProjectileView();
        }

        private void SetProjectileView() 
        {
            _projectileView.SetProjectileView(_projectileModel.ProjectileSprite);
        }

        private void SetProjectileVelocity() 
        {
            _rBody.velocity = Vector2.up * _projectileModel.ProjectileSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            BallController ballController = collision.gameObject.GetComponent<BallController>();
            WallController wallController = collision.gameObject.GetComponent<WallController>();

            if (ballController != null || wallController != null)
            {
                DestroyProjectile();
            }
        }

        private void DestroyProjectile() 
        {
            GameplayEvents.Instance.ProjectileDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
