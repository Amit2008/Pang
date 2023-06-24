using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{
    /// <summary>
    /// This class is used to create events that will be called during gameplay.
    /// </summary>
    public class GameplayEvents : MonoSingelton<GameplayEvents>
    {
        // Creation Events
        public Action<Transform, Vector2> WallsCreated; // This is the event that will be called when the walls are created. The Transform and Vector2 the bottom wall needed data.
        public Action PlayerCreated; // This is the event that will be called when the player is created.

        // Player Controlls Events
        public Action<Transform> PlayerAttemptedShooting; // This is the event that will be called when the player attempts to shoot. The Transform is the projectile spawner.
        public Action PlayerPressedMoveLeftButton; // This is the event that will be called when the player presses the move left button.
        public Action PlayerPressedMoveRightButton; // This is the event that will be called when the player presses the move right button.
        public Action PlayerReleasedMovementButton; // This is the event that will be called when the player releases the movement button.
        public Action PlayerPressedShootingKey; // This is the event that will be called when the player presses the shooting key.

        // Ball Controlls Events
        public Action BallHitPlayer; // This is the event that will be called when the ball hits the player.
        public Action<Vector2, int> BallHitProjectile; // This is the event that will be called when the ball hits the projectile. The Vector2 is the ball position. int is the ball level
        public Action BallDestroyed; // This is the event that will be called when the ball is destroyed.
        //Projectile Controlls Events
        public Action ProjectileDestroyed; // This is the event that will be called when the projectile is out of the screen.

        //Game end events
        public Action ResetGameplaySceneClicked; // This is the event that will be called when the reset gameplay scene button is clicked.
        public Action GameSceneReset; // This is the event that will be called when the game scene is reset.
        public Action<bool> GameEnded; // This is the event that will be called when the game is ended.
    }
}
