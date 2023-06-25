using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is responsible for injecting ball data into ball controllers.
    /// </summary>
    public class BallControllerDataBinder : MonoBehaviour
    {
        [SerializeField] private BallModel _ballModel;

        /// <summary>
        /// Gets the ball model associated with this data binder.
        /// </summary>
        public BallModel BallModel => _ballModel;

        /// <summary>
        /// Injects the ball data to the specified list of ball controllers.
        /// </summary>
        /// <param name="ballControllers">The list of ball controllers to inject data into.</param>
        /// <param name="ballScale">The scale of the ball.</param>
        /// <param name="ballLevel">The level of the ball.</param>
        /// <param name="isMovingFirstRight">Flag indicating the initial movement direction.</param>
        public void InjectBallDataToControllers(List<BallController> ballControllers, Vector2 ballScale, int ballLevel, bool isMovingFirstRight)
        {
            foreach (BallController ballController in ballControllers)
            {
                ballController.InjectBallData(_ballModel, ballScale, ballLevel, isMovingFirstRight);
            }
        }
    }
}

