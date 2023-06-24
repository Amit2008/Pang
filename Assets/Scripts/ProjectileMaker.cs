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
            _currentAlliveProjectiles++;
            if (_currentAlliveProjectiles > LevelModelDataHolder.Instance.LevelModel.MaxAmountOfBullets) 
            {
                _currentAlliveProjectiles = LevelModelDataHolder.Instance.LevelModel.MaxAmountOfBullets;
            }
        }
        
        private void MakeProjectile(Transform spawnPoint) 
        {
            if (_currentAlliveProjectiles <= 0) return;

            _currentAlliveProjectiles--;
            GameObject projectileObj = Instantiate(_projectilePrefab, spawnPoint.position, Quaternion.identity);
            ProjectileController projectileController = projectileObj.GetComponent<ProjectileController>();
            _projectileControllerDataBinder.SetProjectileControllerData(projectileController);
        }
    }
}
