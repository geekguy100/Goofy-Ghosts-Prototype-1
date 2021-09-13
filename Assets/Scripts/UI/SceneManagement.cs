using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagement: MonoBehaviour
{
    public static SceneManagement instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadSceneAsyncAdditive("MainMenu"));
    }

    public void LoadCredits()
    {
        StartCoroutine(LoadSceneAsyncAdditive("Credits"));
    }

    public void LoadHowToPlay()
    {
        StartCoroutine(LoadSceneAsyncAdditive("HowToPlay"));
    }

    public void LoadPauseMenu()
    {
        StartCoroutine(LoadSceneAsyncAdditive("PauseMenu"));
    }

    public void LoadStage1()
    {
        StartCoroutine(LoadSceneAsyncAdditive("KyleScene 1"));
    }

    public void LoadStage2()
    {
        StartCoroutine(LoadSceneAsyncAdditive("Stage 2"));
    }

    public void LoadStage3()
    {
        StartCoroutine(LoadSceneAsyncAdditive("Stage 3"));
    }

    public void LoadStage4()
    { 
        StartCoroutine(LoadSceneAsyncAdditive("Stage 4"));
    }

    private Scene previousScene;
    public IEnumerator LoadSceneAsyncAdditive(string sceneName, bool unloadPrevious = true)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!op.isDone)
        {
            yield return null;
        }

        if (unloadPrevious && previousScene != null)
        {
            print("UNLOADING");
            StartCoroutine(UnloadSceneAsync(previousScene));
        }

        previousScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    public IEnumerator UnloadSceneAsync(Scene scene)
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(scene);
        while (!op.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
