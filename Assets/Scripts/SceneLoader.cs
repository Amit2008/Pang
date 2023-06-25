using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pang
{
    /// <summary>
    /// This class is responsible for loading and unloading scenes.
    /// </summary>
    public class SceneLoader
    {
        private string _lastSceneNameLoaded;

        /// <summary>
        /// Loads a scene asynchronously while optionally unloading a previous scene.
        /// </summary>
        /// <param name="sceneNameToLoad">The name of the scene to load.</param>
        /// <param name="sceneNameToUnload">The name of the scene to unload (optional).</param>
        /// <param name="parameters">The load scene parameters.</param>
        public void LoadScene(string sceneNameToLoad, string sceneNameToUnload, LoadSceneParameters parameters)
        {
            var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneNameToLoad, parameters);

            if (!string.IsNullOrEmpty(sceneNameToUnload))
            {
                _lastSceneNameLoaded = sceneNameToUnload;
                asyncOperation.completed += UnloadCurrentScene;
            }
        }

        /// <summary>
        /// Unloads the previously loaded scene.
        /// </summary>
        /// <param name="asyncOperation">The completed async operation.</param>
        private void UnloadCurrentScene(AsyncOperation asyncOperation)
        {
            asyncOperation.completed -= UnloadCurrentScene;
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_lastSceneNameLoaded);
        }
    }
}

