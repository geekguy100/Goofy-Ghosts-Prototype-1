/*****************************************************************************
// File Name :         AudioClipSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/05/2021
//
// Brief Description : A ScriptableObject that holds data about an audio clip that can be played
                       by the AudioManager.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "AudioClipSO")]
public class AudioClipSO : ScriptableObject
{
    [Tooltip("The AudioClip to play.")]
    [SerializeField] private AudioClip audioClip;
    /// <summary>
    /// The AudioClip to play.
    /// </summary>
    public AudioClip AudioClip
    {
        get
        {
            return audioClip;
        }
    }

    [Tooltip("The AudioMixer to route the SFX through.")]
    [SerializeField] private AudioMixerGroup mixerGroup;
    /// <summary>
    /// The AudioMixer to route the SFX through.
    /// </summary>
    public AudioMixerGroup MixerGroup
    {
        get
        {
            return mixerGroup;
        }
    }

    [Tooltip("The pitch the audio clip will play at.")]
    [SerializeField] private float pitch = 1f;
    /// <summary>
    /// The pitch the audio clip will play at.
    /// </summary>
    public float Pitch
    {
        get
        {
            return pitch;
        }
    }

    [Tooltip("The volume the audio clip will play at.")]
    [SerializeField] private float volume = 1f;
    /// <summary>
    /// The volume the audio clip will play at.
    /// </summary>
    public float Volume
    {
        get
        {
            return volume;
        }
    }
}