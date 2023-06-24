using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to set the wall view.
    /// </summary>
    public class WallView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public void SetWall(Sprite wallSprite, Vector2 wallPosition, Vector2 wallScale) 
        {
            //With the injected data we can set the wall view
            InitView(wallSprite, wallPosition, wallScale);
        }

        private void InitView(Sprite wallSprite, Vector2 wallPosition, Vector2 wallScale) 
        {
            // First, check if the sprite renderer is null and get it if it is
            if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();

            //Then, if it is not null, set the wall sprite, position and scale
            _spriteRenderer.sprite = wallSprite;
            transform.position = wallPosition;
            transform.localScale = wallScale;
        } 
    }
}
