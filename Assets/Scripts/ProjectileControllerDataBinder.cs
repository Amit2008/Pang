using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    public class ProjectileControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private ProjectileModel _projectileModel;

        public void SetProjectileControllerData(ProjectileController projectileController) 
        {
            if (projectileController != null) 
            {
                projectileController.SetProjectileData(_projectileModel);
            }
        }
    }
}
