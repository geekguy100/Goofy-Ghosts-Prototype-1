/*****************************************************************************
// File Name :         Goal.cs
// Author :            Kyle Grenier
// Creation Date :     09/13/2021
//
// Brief Description : Can only collide w/ Player. Loads the next level on trigger entered.
*****************************************************************************/
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private SceneLoaderSO sceneLoader;
    [SerializeField] private string sceneName;

    [SerializeField] private AudioClipSO enterSFX;
    [SerializeField] private AudioClipChannelSO sfxChannel;
    [SerializeField] private bool finalGoal;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(finalGoal)
        {
            PlayerPrefs.SetInt("BeatGame", 1);
        }
        sfxChannel.RaiseEvent(enterSFX);
        sceneLoader.LoadSceneAsyncAdditive(sceneName);
    }
}