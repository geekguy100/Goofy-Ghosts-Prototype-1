/*****************************************************************************
// File Name :         MainMenuBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     #CREATIONDATE#
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private BoolChannelSO togglePauseChannel;

    /// <summary>
    /// Force unpause the game.
    /// </summary>
    private void Start()
    {
        togglePauseChannel.RaiseEvent(false);
    }
}
