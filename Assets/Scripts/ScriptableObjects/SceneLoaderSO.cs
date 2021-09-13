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
    public void LoadMainMenu()
    {
        LoadSceneAsyncAdditive("MainMenu");
    }

    public void LoadCredits()
    {
        LoadSceneAsyncAdditive("Credits");
    }

    public void LoadHowToPlay()
    {
        LoadSceneAsyncAdditive("HowToPlay");
    }

    public void LoadPauseMenu()
    {
        LoadSceneAsyncAdditive("PauseMenu");
    }

    public void LoadStage1()
    {
        LoadSceneAsyncAdditive("KyleScene 1");
    }

    public void LoadStage2()
    {
        LoadSceneAsyncAdditive("Stage 2");
    }

    public void LoadStage3()
    {
        LoadSceneAsyncAdditive("Stage 3");
    }

    public void LoadStage4()
    {
        LoadSceneAsyncAdditive("Stage 4");
    }

    private Scene? previousScene = null;
    public void LoadSceneAsyncAdditive(string sceneName, bool unloadPrevious = true)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        op.completed += _ => { HandlePostLoad(sceneName, unloadPrevious); };
    }

    private void HandlePostLoad(string sceneName, bool unloadPrevious)
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
