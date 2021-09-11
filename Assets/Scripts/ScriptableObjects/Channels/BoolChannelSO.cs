/*****************************************************************************
// File Name :         BoolChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A channel that accepts and broadcasts bool events.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/Bool Channel", fileName = "New Bool Channel")]
public class BoolChannelSO : ScriptableObject
{
    /// <summary>
    /// The UnityAction accepting subscribers.
    /// </summary>
    public UnityAction<bool> OnEventRaised;

    /// <summary>
    /// Invokes the event associated with this channel.
    /// </summary>
    /// <param name="b">The boolean to use as an argument.</param>
    public void RaiseEvent(bool b)
    {
        OnEventRaised?.Invoke(b);
    }
}