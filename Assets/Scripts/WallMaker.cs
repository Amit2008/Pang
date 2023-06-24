using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to create the walls in the game.
    /// </summary>
    [RequireComponent(typeof(WallControllerDataBinder))]
    public partial class WallMaker : MonoBehaviour
    {
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private Transform _wallsParent;

        private WallControllerDataBinder wallDataInjector;

        private void Awake()
        {
            wallDataInjector = GetComponent<WallControllerDataBinder>();
        }
        private void Start()
        {
            CreateWalls();
        }

        private void OnEnable()
        {
            GameplayEvents.Instance.GameSceneReset += CreateWalls;
        }
        private void OnDisable()
        {
            GameplayEvents.Instance.GameSceneReset -= CreateWalls;
        }
        private void CreateWalls() 
        {
            //First, check if the wall prefab is null
            if (_wallPrefab == null) return;

            //Then, if not, create the walls for each wall type
            Dictionary<WallType, WallController> wallControllers = new Dictionary<WallType, WallController>();
            for (int wallTypeIndex = 0; wallTypeIndex < (int)WallType.Count; wallTypeIndex++)
            {

                //Create the wall object and get the wall controller
                GameObject wallObj = Instantiate(_wallPrefab, Vector2.zero, Quaternion.identity);
                wallObj.name = "Wall " + (WallType)wallTypeIndex;
                var wallController = wallObj.GetComponent<WallController>();
                wallObj.transform.parent = _wallsParent;

                // Then, if the wall controller is not null, set the wall data
                if (wallController != null)
                {
                    wallControllers.Add((WallType)wallTypeIndex, wallController);
                }
                else
                {
                    Debug.LogError("CreateWalls: no WallController component on the wall - Error");
                    return;
                }

            }

            // Then, inject the wall data to the wall controllers
            wallDataInjector.InjectWallDataToControllers(wallControllers);

            // Then, raise an event to notify that the walls have been created
            GameplayEvents.Instance.WallsCreated?.Invoke(wallControllers[WallType.Bottom].transform, wallControllers[WallType.Bottom].WallSize);
        }
    }

    public enum WallType
    {
        Top,
        Bottom,
        Left,
        Right,
        Count
    }
}
