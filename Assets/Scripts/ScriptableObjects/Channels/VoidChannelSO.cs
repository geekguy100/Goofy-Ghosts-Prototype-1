/*****************************************************************************
// File Name :         VoidChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A channel that accepts and broadcasts void events.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/Void Channel", fileName = "New Void Channel")]
public class VoidChannelSO : MonoBehaviour
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}