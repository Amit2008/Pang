using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is the view of the projectile and it contains the visual representation of the projectile.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ProjectileView : MonoBehaviour
    {
        private SpriteRenderer _projectileRenderer;

        private void Awake()
        {
            // Get the SpriteRenderer component attached to the same GameObject.
            _projectileRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Sets the visual representation of the projectile using the provided projectile sprite.
        /// </summary>
        /// <param name="projectileSprite">The sprite to be used as the visual representation of the projectile.</param>
        public void SetProjectileView(Sprite projectileSprite)
        {
            // Assign the provided projectile sprite to the SpriteRenderer to update the visual representation.
            _projectileRenderer.sprite = projectileSprite;
        }
    }
}

