/*****************************************************************************
// File Name :         AudioClipChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/06/2021
//
// Brief Description : A channel that accepts and broadcasts requests to play SFX.
*****************************************************************************/
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Channels/SFX Event Channel", fileName = "New SFX Event Channel")]
public class AudioClipChannelSO : ScriptableObject
{
    public UnityAction<AudioClipSO> OnSFXRequest;

    public void RaiseEvent(AudioClipSO clip)
    {
        OnSFXRequest?.Invoke(clip);
    }
}