using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// this class is responsible for loading and unloading scenes.
/// </summary>
public class SceneLoader
{
    private string _lastSceneNameLoaded;
    public void LoadScene(string sceneNameToLoad, string sceneNameToUnload, LoadSceneParameters parameters)
    {
        var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneNameToLoad, parameters);

        if (!string.IsNullOrEmpty(sceneNameToUnload))
        {
            _lastSceneNameLoaded = sceneNameToUnload;
            asyncOperation.completed += UnloadCurrentScene;
        }
    }

    private void UnloadCurrentScene(AsyncOperation asyncOperation)
    {
        asyncOperation.completed -= UnloadCurrentScene;
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_lastSceneNameLoaded);
    }
}
