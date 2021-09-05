/*****************************************************************************
// File Name :         IWeapon.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : An abstract class defining the necessary functionality for all in-game Weapons.
*****************************************************************************/
using UnityEngine;
using System;
using System.Collections;

public abstract class IWeapon : MonoBehaviour
{
    [Header("IWeapon Fields")]
    [Tooltip("The data associated with this weapon.")]
    [SerializeField] protected WeaponData weaponData;

    [Tooltip("The Transform indicating the bullet's spawn position.")]
    [SerializeField] protected Transform bulletSpawnPos;

    /// <summary>
    /// The amount of bullets currently in the clip.
    /// </summary>
    private int currentClipSize;

    /// <summary>
    /// True if the player can fire the weapon.
    /// </summary>
    private bool canFire = true;

    /// <summary>
    /// True if the player is in the process of firing (holding down the Fire button).
    /// </summary>
    private bool firing = false;

    /// <summary>
    /// True if the player is in the process of reloading the weapon.
    /// </summary>
    private bool reloading = false;

    // Actions
    /// <summary>
    /// Invoked when the weapon is fired.
    /// </summary>
    public Action OnWeaponFire;
    /// <summary>
    /// Invoked when the weapon's reload sequence is started.
    /// </summary>
    public Action OnWeaponReload;
    /// <summary>
    /// Invoked when the weapon is fired and the magazine is empty.
    /// </summary>
    public Action OnClipEmpty;

    private void Awake()
    {
        currentClipSize = weaponData.ClipSize;
    }

    #region -- Weapon Firing --
    /// <summary>
    /// Shoots a bullet from the weapon.
    /// </summary>
    public virtual void Fire()
    {
        if (currentClipSize == 0)
        {
            OnClipEmpty?.Invoke();
            return;
        }

        if (!firing)
        {
            firing = true;
            StartCoroutine(ShootBullet());
        }
    }

    public void ReleaseFire()
    {
        firing = false;
    }

    private IEnumerator ShootBullet()
    {
        do
        {
            // Only shoot a bullet if the player can fire.
            if (canFire)
            {
                OnWeaponFire?.Invoke();

                // Decrease the weapon's clip size if
                // the player does not have infinite ammo.
                if (currentClipSize != -1)
                {
                    currentClipSize -= 1;
                }

                Instantiate(weaponData.BulletPrefab, bulletSpawnPos.position, transform.rotation);
                StartCoroutine(Cooldown());
            }

            yield return null;
        }
        // Continue shooting if the weapon is an automatic weapon.
        while (weaponData.weaponType == WeaponData.WeaponType.AUTOMATIC && firing);
    }

    /// <summary>
    /// Waits the fire rate time before the player can fire the weapon again.
    /// </summary>
    private IEnumerator Cooldown()
    {
        canFire = false;
        float cooldownTime = 0f;
        while(cooldownTime < weaponData.FireRate)
        {
            cooldownTime += Time.deltaTime;
            yield return null;
        }

        canFire = true;
    }
    #endregion

    #region -- Weapon Reloading --
    /// <summary>
    /// Reloads the weapon.
    /// </summary>
    public virtual void Reload()
    {
        // Only reload if the player isn't already reloading and
        // they do not have an infinite clip size.
        if (!reloading && currentClipSize != -1)
        {
            OnWeaponReload?.Invoke();
            StartCoroutine(ReloadWeapon());
        }
    }

    /// <summary>
    /// Reloads the weapon after a specified amount of time.
    /// </summary>
    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(weaponData.ReloadTime);
        currentClipSize = weaponData.ClipSize;
        reloading = false;
    }
    #endregion

    /// <summary>
    /// Returns the weapon's WeaponType.
    /// </summary>
    /// <returns>The weapon's WeaponType.</returns>
}