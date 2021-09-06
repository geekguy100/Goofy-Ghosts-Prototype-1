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

    [Tooltip("The ability cooldown channel to broadcast to.")]
    [SerializeField] private AbilityCooldownChannelSO abilityCooldownChannel;

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
        abilityCooldownChannel.RaiseEvent(GetCooldownTime());
        coolingDown = true;
        yield return new WaitForSeconds(GetCooldownTime());
        coolingDown = false;
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