using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is the model of the projectile and it contains the data of the projectile.
    /// </summary>
    [CreateAssetMenu(fileName = "New projectile configurations", menuName = "Pang/Level/Projectile")]
    public class ProjectileModel : ScriptableObject
    {
        [SerializeField] private Sprite _projectileSprite;
        [SerializeField] private float projectileSpeed;

        public Sprite ProjectileSprite => _projectileSprite;
        public float ProjectileSpeed => projectileSpeed;
    }
}
