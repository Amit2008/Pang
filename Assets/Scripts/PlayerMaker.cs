using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to create the player and inject the player data to the player controllers.
    /// </summary>
    [RequireComponent(typeof(PlayerControllerDataBinder))]
    public class PlayerMaker : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _parent;

        private PlayerControllerDataBinder playerDataInjector;

        private void Awake()
        {
            playerDataInjector = GetComponent<PlayerControllerDataBinder>();
        }

        private void OnEnable()
        {
            GameplayEvents.Instance.WallsCreated += CreatePlayer;
        }
        private void OnDisable()
        {
            if (GameplayEvents.Instance == null) return;

            GameplayEvents.Instance.WallsCreated -= CreatePlayer;
        }

        private void CreatePlayer(Transform bottomWall, Vector2 sizeOfBottomWall)
        {
            List<PlayerController> playerControllers = new List<PlayerController>();

            // Create the player here.
            GameObject playerObj = Instantiate(_playerPrefab);
            playerControllers.Add(playerObj.GetComponent<PlayerController>());
            playerObj.transform.SetParent(_parent);

            // Set the position of the player to the middle of the bottom wall.
            playerObj.transform.position = new Vector3(bottomWall.position.x, bottomWall.position.y + sizeOfBottomWall.y / 2f, 0);

            //Then, inject the player data to the player controllers
            playerDataInjector.InjectPlayerDataToControllers(playerControllers);

            //Then, raise the event that the player has been created.
            GameplayEvents.Instance.PlayerCreated?.Invoke();
        }
    }
}