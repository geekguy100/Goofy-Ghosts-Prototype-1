/*****************************************************************************
// File Name :         FloatChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : A SO reponsible for accepting and broadcasting events requiring floats.
*****************************************************************************/
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Channels/Float Channel", fileName = "New Float Channel")]
public class FloatChannelSO : ScriptableObject
{
    public UnityAction<float> OnEventRaised;

    /// <summary>
    /// Raises the event.
    /// </summary>
    /// <param name="f">The float to pass into the event.</param>
    public void RaiseEvent(float f)
    {
        OnEventRaised?.Invoke(f);
    }
}