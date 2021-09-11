/*****************************************************************************
// File Name :         PlasmaGun.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : A weapon that shoots balls of electricity.
                       Decreases the weapon holder's health on use.
*****************************************************************************/
using UnityEngine;

public class PlasmaGun : IWeapon
{
    /// <summary>
    /// The weapon holder's HealthManager component.
    /// </summary>
    private HealthManager healthManager;

    [Header("Plasma Gun Fields")]
    [Tooltip("The amount of damage the weapon inflicts on the weapon holder.")]
    [SerializeField] private float damageToEntity;

    /// <summary>
    /// Getting the weapon holder's HealthManager.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        healthManager = GetComponentInParent<HealthManager>();
    }

    /// <summary>
    /// Decreaing the weapon holder's health on use.
    /// </summary>
    protected override void OnWeaponFire()
    {
        healthManager.CurrentHealth -= damageToEntity;
    }
}