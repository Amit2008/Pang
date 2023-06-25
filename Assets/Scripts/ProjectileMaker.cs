using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to make projectiles and inject the projectile data to the projectile controllers.
    /// </summary>
    [RequireComponent(typeof(ProjectileControllerDataBinder))]
    public class ProjectileMaker : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;

        private ProjectileControllerDataBinder _projectileControllerDataBinder;
        private int _currentAlliveProjectiles = 0;

        private void Awake()
        {
            _projectileControllerDataBinder = GetComponent<ProjectileControllerDataBinder>();
        }

        private void Start()
        {
            // Set the initial amount of alive projectiles based on the maximum amount defined in the level model.
            _currentAlliveProjectiles = LevelModelDataHolder.Instance.LevelModel.MaxAmountOfBullets;
        }

        private void OnEnable()
        {
            GameplayEvents.Instance.PlayerAttemptedShooting += MakeProjectile;
            GameplayEvents.Instance.ProjectileDestroyed += AllowMakingNewProjectile;
        }

        private void OnDisable()
        {
            GameplayEvents.Instance.PlayerAttemptedShooting -= MakeProjectile;
            GameplayEvents.Instance.ProjectileDestroyed -= AllowMakingNewProjectile;
        }

        private void AllowMakingNewProjectile()
        {
            // Increment the count of alive projectiles and limit it to the maximum amount defined in the level model.
            _currentAlliveProjectiles++;
            if (_currentAlliveProjectiles > LevelModelDataHolder.Instance.LevelModel.MaxAmountOfBullets)
            {
                _currentAlliveProjectiles = LevelModelDataHolder.Instance.LevelModel.MaxAmountOfBullets;
            }
        }

        private void MakeProjectile(Transform spawnPoint)
        {
            // Check if there are available alive projectiles to be created.
            if (_currentAlliveProjectiles <= 0) return;

            // Decrement the count of alive projectiles and create a new projectile.
            _currentAlliveProjectiles--;
            GameObject projectileObj = Instantiate(_projectilePrefab, spawnPoint.position, Quaternion.identity);
            ProjectileController projectileController = projectileObj.GetComponent<ProjectileController>();
            _projectileControllerDataBinder.SetProjectileControllerData(projectileController);
        }
    }
}

