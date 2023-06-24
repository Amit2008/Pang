using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This script is used to control the floor object in the game.
    /// </summary>
    [RequireComponent(typeof(WallView))]
    public class WallController : MonoBehaviour
    {
        private WallView _floorView;
        private WallType _wallType;
        private WallModel _wallModel;
        private Camera _mainCamera;

        public Vector2 WallSize => _wallModel.GetWallSpriteWidthAndHeight();
        public WallType WallType => _wallType;
        public void SetWallData(WallModel wallModel, WallType wallType) 
        {
            _wallModel= wallModel;
            _wallType = wallType;
            SetWallView();
        }

        private void SetWallView() 
        {
            //First stash camera and floorView
            _mainCamera = Camera.main;
            _floorView = GetComponent<WallView>();

            //Then, if they are not null, set the floor view
            if (_floorView != null || _wallModel != null || _mainCamera != null)
            {
                Vector2 wallPos = CalculateWallPosition(_wallType);
                Vector2 WallScale = CalculateWallScale(_wallType);
                _floorView.SetWall(_wallModel.wallSprite, wallPos, WallScale);
            }
            else
            {
                Debug.LogError("SetWallView: FloorView or FloorModel is null - Error");
            }
        }

        private Vector2 CalculateWallPosition(WallType wallType) 
        {
            //Get the screen size
            float height = _mainCamera.orthographicSize * 2;
            float width = height * _mainCamera.aspect;

            Vector2 wallWidthAndHeight = WallSize;
            Vector2 wallPosition = Vector2.zero;

            switch (wallType)
            {
                case WallType.Top:
                    wallPosition = new Vector2(0, height / 2f + wallWidthAndHeight.y / 2f);
                    break;
                case WallType.Bottom:
                    wallPosition = new Vector2(0, -height / 2f);
                    break;
                case WallType.Left:
                    wallPosition = new Vector2(-width / 2f - wallWidthAndHeight.x / 2f, 0);
                    break;
                case WallType.Right:
                    wallPosition = new Vector2(width / 2f + wallWidthAndHeight.x / 2f, 0);
                    break;
            }

            return wallPosition;
        }
        private Vector2 CalculateWallScale(WallType wallType)
        {
            //Get the screen size
            float height = _mainCamera.orthographicSize * 2;
            float width = height * _mainCamera.aspect;

            Vector2 wallScale = Vector2.one;
            
            //Set the walls scale
            switch (wallType)
            {
                case WallType.Top:
                case WallType.Bottom:
                    wallScale = new Vector2(width, 1);
                    break;
                case WallType.Left:
                case WallType.Right:
                    wallScale = new Vector2(1, height);
                    break;
            }
            return wallScale;
        }
    }
}
