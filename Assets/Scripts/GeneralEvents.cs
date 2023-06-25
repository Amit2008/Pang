using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pang
{

    /// <summary>
    /// This class is used to store all general events that are used in the game.
    /// </summary>
    public class GeneralEvents : MonoSingleton<GeneralEvents>
    {
        public Action<LevelModel> LevelButtonClicked; // This is the event that will be invoked when the level button is clicked
        public Action LevelReadyToBeLoaded; // This is the event that will be invoked when the level model data is saved
        public Action<string> GoToMainSceneEventRaised; // This is the event that will be invoked when the main scene button is clicked
    }
}