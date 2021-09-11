/*****************************************************************************
// File Name :         IAbility.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Defines a contract that all ability's must include.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public abstract class IAbility : MonoBehaviour
{
    // MEMBER VARIABLES

    [Header("Channels")]

    [Tooltip("The ability used channel to broadcast to.")]
    [SerializeField] private FloatChannelSO abilityUsedChannel;
    [Tooltip("The channel that accepts and broadcasts requests to play SFX.")]
    [SerializeField] private AudioClipChannelSO sfxChannel;

    [Header("SFX")]
    [Tooltip("AudioClipSO played when the abiltiy is activated.")]
    [SerializeField] private AudioClipSO abilityUsedClip;
    [Tooltip("AudioClipSO played when the ability's cooldown is over.")]
    [SerializeField] private AudioClipSO abilityOverClip;

    /// <summary>
    /// True if the ability is cooling down.
    /// </summary>
    protected bool coolingDown;

/*****************************************************************************************/

    // METHODS

    /// <summary>
    /// Initializing member variables.
    /// </summary>
    protected virtual void Awake()
    {
        coolingDown = false;
    }

    /// <summary>
    /// Called when the ability is activated.
    /// </summary>
    public virtual void Activate()
    {
        abilityUsedChannel.RaiseEvent(GetCooldownTime());
        sfxChannel.RaiseEvent(abilityUsedClip);
        StartCoroutine(Cooldown());
    }

    #region -- Cooldown Functionality --
    /// <summary>
    /// Returns the ability's cooldown time (i.e. the time until the ability is no longer usable.
    /// </summary>
    /// <returns>The ability's cooldown time.</returns>
    public abstract float GetCooldownTime();

    /// <summary>
    /// Waits an amount of time before the ability is no longer usable.
    /// </summary>
    private IEnumerator Cooldown()
    {
        coolingDown = true;
        yield return new WaitForSeconds(GetCooldownTime());
        coolingDown = false;
        sfxChannel.RaiseEvent(abilityOverClip);
        OnCooldownComplete();
    }

    /// <summary>
    /// Invoked after the ability's cooldown is complete.
    /// </summary>
    protected abstract void OnCooldownComplete();

    /// <summary>
    /// Returns true if the ability is cooling down.
    /// </summary>
    /// <returns>True if the ability is cooling down.</returns>
    public bool IsCoolingDown()
    {
        return coolingDown;
    }
    #endregion
}