using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to store the player data.
    /// </summary>
    [CreateAssetMenu(fileName = "New Player Model", menuName = "Pang/PlayerData")]
    public class PlayerModel : ScriptableObject
    {
        [SerializeField] private Sprite _playerSprite;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private PlayerType _playerType;

        [Header("Action Buttons")]
        [SerializeField] private KeyCode _moveLeftKeyCode;
        [SerializeField] private KeyCode _moveRightKeyCode;
        [SerializeField] private KeyCode _shootKeyCode;

        /// <summary>
        /// The sprite representing the player.
        /// </summary>
        public Sprite PlayerSprite => _playerSprite;

        /// <summary>
        /// The movement speed of the player.
        /// </summary>
        public float MoveSpeed => _moveSpeed;

        /// <summary>
        /// The KeyCode for moving the player to the left.
        /// </summary>
        public KeyCode MoveLeftKeyCode => _moveLeftKeyCode;

        /// <summary>
        /// The KeyCode for moving the player to the right.
        /// </summary>
        public KeyCode MoveRightKeyCode => _moveRightKeyCode;

        /// <summary>
        /// The KeyCode for shooting projectiles.
        /// </summary>
        public KeyCode ShootKeyCode => _shootKeyCode;
    }
}

