using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Pang
{
    /// <summary>
    /// This class manages the loading and unloading of scenes in the game.
    /// </summary>
    [DefaultExecutionOrder(-49)]
    public class SceneManager : MonoBehaviour
    {
        private SceneLoader sceneLoader;
        [SerializeField] float delayBeforeSceneLoading = 0.75f;

        private LoadSceneParameters additieveParameters;

        private void Awake()
        {
            sceneLoader = new SceneLoader();
            additieveParameters = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.None);
        }

        private void OnEnable()
        {
            GeneralEvents.Instance.LevelReadyToBeLoaded += LoadGameplayScene;
            GeneralEvents.Instance.GoToMainSceneEventRaised += LoadMainMenuScene;
        }

        private void OnDisable()
        {
            GeneralEvents.Instance.LevelReadyToBeLoaded -= LoadGameplayScene;
            GeneralEvents.Instance.GoToMainSceneEventRaised -= LoadMainMenuScene;
        }

        private void Start()
        {
            LoadMainMenuScene();
        }

        /// <summary>
        /// Loads the main menu scene.
        /// </summary>
        /// <param name="levelToUnload">The name of the level scene to unload.</param>
        private void LoadMainMenuScene(string levelToUnload = null)
        {
            StartCoroutine(LoadLevelSequence(GameConstants.MainMenuSceneName, levelToUnload));
        }

        /// <summary>
        /// Loads the gameplay scene.
        /// </summary>
        private void LoadGameplayScene()
        {
            StartCoroutine(LoadLevelSequence(GameConstants.GameplaySceneName, GameConstants.MainMenuSceneName));
        }

        /// <summary>
        /// Loads a scene with a delay before loading.
        /// </summary>
        /// <param name="sceneNameToLoad">The name of the scene to load.</param>
        /// <param name="sceneNameToUnload">The name of the scene to unload.</param>
        private IEnumerator LoadLevelSequence(string sceneNameToLoad, string sceneNameToUnload)
        {
            yield return new WaitForSeconds(string.IsNullOrEmpty(sceneNameToUnload) ? 0 : delayBeforeSceneLoading);
            sceneLoader.LoadScene(sceneNameToLoad, sceneNameToUnload, additieveParameters);
        }
    }
}
