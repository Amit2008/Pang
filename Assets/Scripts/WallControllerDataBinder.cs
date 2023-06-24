using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    public class WallControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private WallModel _wallModel;

        public void InjectWallDataToControllers(Dictionary<WallType, WallController> wallControllers)
        {
            foreach (var wallController in wallControllers)
            {
                wallController.Value.SetWallData(_wallModel, wallController.Key);
            }
        }
    }
}
