/*****************************************************************************
// File Name :         PauseMenuBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     09/13/2021
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{
    [SerializeField] private BoolChannelSO pauseChannel;
    [SerializeField] private GameObject pauseMenu;

    private void OnEnable()
    {
        pauseChannel.OnEventRaised += Toggle;
    }

    private void OnDisable()
    {
        pauseChannel.OnEventRaised -= Toggle;
    }

    private void Toggle(bool paused)
    {
        pauseMenu.SetActive(paused);
    }
}
