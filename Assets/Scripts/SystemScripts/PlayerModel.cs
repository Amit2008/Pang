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

        public Sprite PlayerSprite => _playerSprite;
        public float MoveSpeed => _moveSpeed;

        public KeyCode MoveLeftKeyCode => _moveLeftKeyCode;
        public KeyCode MoveRightKeyCode => _moveRightKeyCode;
        public KeyCode ShootKeyCode => _shootKeyCode;
    } 
}
