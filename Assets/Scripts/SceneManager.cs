using Codice.CM.Common;
using Pang;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
    private void Start()
    {
        LoadMainMenuScene();
    }

    private void LoadMainMenuScene(string levelToUnload = null)
    {
        StartCoroutine(LoadLevelSequence(GameConstants.MainMenuSceneName, levelToUnload));
    }
    private void LoadGameplayScene()
    {
        StartCoroutine(LoadLevelSequence(GameConstants.GameplaySceneName, GameConstants.MainMenuSceneName));
    }
    private IEnumerator LoadLevelSequence(string sceneNameToLoad, string sceneNameToUnload)
    {
        yield return new WaitForSeconds(string.IsNullOrEmpty(sceneNameToUnload) ? 0 : delayBeforeSceneLoading);
        sceneLoader.LoadScene(sceneNameToLoad, sceneNameToUnload, additieveParameters);
    }
}