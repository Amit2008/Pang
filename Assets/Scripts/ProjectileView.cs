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
            _projectileRenderer = GetComponent<SpriteRenderer>();
        }
        public void SetProjectileView(Sprite projectileSprite) 
        {
            _projectileRenderer.sprite = projectileSprite;
        }
    }
}
