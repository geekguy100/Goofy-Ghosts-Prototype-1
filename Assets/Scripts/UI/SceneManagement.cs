using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement: MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void LoadPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage 2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("Stage 3");
    }

    public void LoadStage4()
    { 
        SceneManager.LoadScene("Stage 4");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
