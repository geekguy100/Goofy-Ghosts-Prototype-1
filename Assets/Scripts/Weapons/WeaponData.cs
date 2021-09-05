/*****************************************************************************
// File Name :         WeaponData.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : A ScriptableObject that holds a weapon's data.
*****************************************************************************/
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Tooltip("The name of the weapon.")]
    [SerializeField] private string weaponName;
    /// <summary>
    /// The name of the weapon.
    /// </summary>
    public string WeaponName
    {
        get
        {
            return weaponName;
        }
    }

    [Tooltip("The bullet prefab that this weapon will fire.")]
    [SerializeField] private GameObject bulletPrefab;
    /// <summary>
    /// The bullet prefab that this weapon will fire.
    /// </summary>
    public GameObject BulletPrefab
    {
        get
        {
            return bulletPrefab;
        }
    }

    [Tooltip("The weapon's rate of fire in seconds.")]
    [SerializeField] private float fireRate;
    /// <summary>
    /// The weapon's rate of fire in seconds.
    /// </summary>
    public float FireRate
    {
        get
        {
            return fireRate;
        }
    }

    [Tooltip("The amount of bullets per clip. -1 for infinite bullets per clip.")]
    [SerializeField] private int clipSize;
    /// <summary>
    /// The amount of bullets per clip. -1 for infinite bullets per clip.
    /// </summary>
    public int ClipSize
    {
        get
        {
            return clipSize;
        }
    }

    [Tooltip("The amount of time in seconds it takes to reload the weapon.")]
    [SerializeField] private float reloadTime;
    public float ReloadTime
    {
        get
        {
            return reloadTime;
        }
    }

    public enum WeaponType { SEMI_AUTO, AUTOMATIC };

    [Tooltip("The weapon's type (Semi-Auto or Automatic)")]
    public WeaponType weaponType;

    [Header("Audio Clips")]

    [Tooltip("Audio clip to play when the weapon is fired.")]
    [SerializeField] private AudioClip weaponFireClip;
    [Tooltip("Audio clip to play when the weapon's magazine is empty.")]
    [SerializeField] private AudioClip weaponEmptyClip;
    [Tooltip("Audio clip to play when the weapon is reloaded.")]
    [SerializeField] private AudioClip weaponReloadClip;
}