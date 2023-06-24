using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to store the wall data.
    /// </summary>
    [CreateAssetMenu(fileName = "New Wall Model", menuName = "Pang/Level/Wall")]
    public class WallModel : ScriptableObject
    {
        [SerializeField] public Sprite wallSprite;

        public Sprite WallSprite => wallSprite;

        public Vector2 GetWallSpriteWidthAndHeight() 
        {
            float width = wallSprite.bounds.size.x;
            float height = wallSprite.bounds.size.y;

            return new Vector2(width, height);
        }
    }

    public enum PlayerType 
    {
        Player1,
        Player2
    }
}
