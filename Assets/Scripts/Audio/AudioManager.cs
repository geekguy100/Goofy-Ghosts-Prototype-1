/*****************************************************************************
// File Name :         AudioManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/05/2021
//
// Brief Description : Manages playing audio clips.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Channel that accepts and broadcasts requests for playing SFX.")]
    [SerializeField] private AudioClipChannelSO sfxChannel;

    /// <summary>
    /// A list of AudioPair structs that continas the clips to play
    /// and the AudioSources that play them.
    /// </summary>
    private List<AudioPair> sfxPairs;

    private void Awake()
    {
        sfxPairs = new List<AudioPair>();
    }

    #region -- Subbing and Unsubbing to Events --
    private void OnEnable()
    {
        sfxChannel.OnSFXRequest += PlaySFX;
    }

    private void OnDisable()
    {
        sfxChannel.OnSFXRequest -= PlaySFX;
    }
    #endregion

    /// <summary>
    /// Plays an AudioClipSO's audio clip.
    /// </summary>
    /// <param name="sfx">The AudioClipSO to play.</param>
    private void PlaySFX(AudioClipSO sfx)
    {
        // If the requested clip is not in the list, create a new AudioSource to handle playing it
        // and add it to the list.
        AudioPair pair = sfxPairs.Find(p => p.Clip == sfx);

        if (pair == null)
        {
            // Setting up new AudioSource.
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.playOnAwake = false;
            newSource.outputAudioMixerGroup = sfx.MixerGroup;
            newSource.clip = sfx.AudioClip;
            newSource.pitch = sfx.Pitch;
            newSource.volume = sfx.Volume;

            // Creating a new AudioPair and adding it to the list.
            AudioPair newPair = new AudioPair(newSource, sfx);
            sfxPairs.Add(newPair);

            pair = newPair;
        }

        pair.Source.Play();
    }
}

/// <summary>
/// A class that holds an AudioClipSO and an AudioSource.
/// </summary>
public class AudioPair
{
    private AudioSource source;
    public AudioSource Source { get { return source; } }

    private AudioClipSO clip;
    public AudioClipSO Clip { get { return clip; } }

    public AudioPair(AudioSource source, AudioClipSO clip)
    {
        this.source = source;
        this.clip = clip;
    }
}