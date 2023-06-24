using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to inject ball data to ball controllers.
    /// </summary>
    public class BallControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private BallModel _ballModel;

        public BallModel BallModel => _ballModel;

        public void InjectBallDataToControllers(List<BallController> ballControllers, Vector2 ballScale, int ballLevel, bool isMovingFirstRight)
        {
            foreach (BallController ballController in ballControllers)
            {
                ballController.InjectBallData(_ballModel, ballScale, ballLevel, isMovingFirstRight);
            }
        }
    }
}
