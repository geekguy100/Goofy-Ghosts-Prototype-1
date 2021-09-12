/*****************************************************************************
// File Name :         PlayerAbilityManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Responsible for managing the player's abilities.
*****************************************************************************/
using UnityEngine;

public class PhaseAbility : IAbility
{
    /// <summary>
    /// The SpriteRenderer component attached to this game object.
    /// </summary>
    private SpriteRenderer rend;

    /// <summary>
    /// The main module of the ParticleSystem component attached to this object.
    /// </summary>
    private ParticleSystem.MainModule main;

    protected override void Awake()
    {
        base.Awake();
        rend = GetComponentInChildren<SpriteRenderer>();

        main = GetComponent<ParticleSystem>().main;
    }

    /// <summary>
    /// Enables the phase ability.
    /// </summary>
    public override void Activate()
    {
        base.Activate();
        PhaseOn();
    }

    #region -- Ability Functionality --
    /// <summary>
    /// Enables the player to walk through phaseable walls.
    /// </summary>
    private void PhaseOn()
    {
        Color c = rend.color;
        c.a /= 2;
        rend.color = c;

        // Trail turns transparent
        Color transparent = new Color(1, 1, 1, 0.05f);
        main.startColor = transparent;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), true);
    }

    /// <summary>
    /// Disables the player's ability to walk through phasable walls.
    /// </summary>
    private void PhaseOff()
    {
        Color c = rend.color;
        c.a *= 2;
        rend.color = c;

        // Trail returns to  solid color
        Color solid = Color.white;
        main.startColor = solid;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Phaseable Wall"), false);
    }
    #endregion

    #region -- Cooldown Functionality --
    /// <summary>
    /// Returns the time until the ability is no longer usable.
    /// </summary>
    public override float GetCooldownTime()
    {
        return 3f;
    }

    /// <summary>
    /// Turns the Phase ability off once the cooldown timer runs out.
    /// </summary>
    protected override void OnCooldownComplete()
    {
        PhaseOff();
    }
    #endregion
}