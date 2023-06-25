using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to inject the projectile data to the projectile controllers.
    /// </summary>
    public class ProjectileControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private ProjectileModel _projectileModel;

        /// <summary>
        /// Sets the projectile data for the given projectile controller.
        /// </summary>
        /// <param name="projectileController">The projectile controller to set the data for.</param>
        public void SetProjectileControllerData(ProjectileController projectileController)
        {
            // Check if the projectile controller is valid.
            if (projectileController != null)
            {
                // Set the projectile data using the assigned projectile model.
                projectileController.SetProjectileData(_projectileModel);
            }
        }
    }
}

