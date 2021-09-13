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
    public void LoadLastLevel()
    {
        if (PlayerPrefs.GetInt("BeatGame") == 1)
        {
            PlayerPrefs.SetInt("BeatGame", 0);
            LoadSceneAsyncAdditive("KyleScene 1");
            return;
        }

        Debug.Log("Trying to load " + PlayerPrefs.GetString("LastLevel"));
        LoadSceneAsyncAdditive(PlayerPrefs.GetString("LastLevel"));
    }

    public void LoadStage1()
    {
        LoadSceneAsyncAdditive("KyleScene 1");
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
        LoadSceneAsyncAdditive("MainMenu");
    }

    private Scene? previousScene = null;
    public void LoadSceneAsyncAdditive(string sceneName, bool unloadPrevious = true)
    {
        //Time.timeScale = 1;

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
