/*****************************************************************************
// File Name :         SceneLoaderSO.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Managers/Scene Loader", fileName = "New Scene Loader")]
public class SceneLoaderSO : ScriptableObject
{
    public void LoadStage1()
    {
        LoadSceneAsyncAdditive("KyleScene 1");
    }

    private Scene? previousScene = null;
    public void LoadSceneAsyncAdditive(string sceneName, bool unloadPrevious = true)
    {
        if (unloadPrevious)
        {
            if (previousScene == null)
            {
                UnloadSceneAsync(SceneManager.GetActiveScene());
            }
            else
            {
                UnloadSceneAsync(previousScene.Value);
            }
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        op.completed += _ => { HandlePostLoad(sceneName, unloadPrevious); };
    }

    private void HandlePostLoad(string sceneName, bool unloadPrevious)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        previousScene = SceneManager.GetActiveScene();
        Debug.Log(previousScene.Value.name);
    }

    private void UnloadSceneAsync(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
