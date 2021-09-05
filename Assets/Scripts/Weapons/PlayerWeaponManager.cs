/*****************************************************************************
// File Name :         PlayerWeaponManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Allows the player to rotate and shoot the weapon.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponManager : MonoBehaviour
{
    private PlayerControls controls;

    [Tooltip("The Transform that has the weapon as its child.")]
    [SerializeField] private Transform weaponParent;

    /// <summary>
    /// The weapon that the player has equipped.
    /// </summary>
    private IWeapon weapon;


    /// <summary>
    /// Gets the IWeapon component.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        weapon = weaponParent.GetComponentInChildren<IWeapon>();
    }

    #region -- Subscribing / Unsubscribing to Input events --
    /// <summary>
    /// Subscribe to all of the input events.
    /// </summary>
    private void OnEnable()
    {
        controls.Player.WeaponFire.performed += OnWeaponFire;
        controls.Player.WeaponFire.Enable();

        controls.Player.WeaponRotate.performed += OnWeaponRotate;
        controls.Player.WeaponRotate.Enable();
    }

    /// <summary>
    /// Unsubscribe to all of the input events.
    /// </summary>
    private void OnDisable()
    {
        controls.Player.WeaponFire.Disable();
        controls.Player.WeaponRotate.Disable();
    }
    #endregion

    /// <summary>
    /// Rotates the weapon according to the cursor's position.
    /// </summary>
    /// <param name="value">The mouse cursor's position.</param>
    private void OnWeaponRotate(InputAction.CallbackContext ctx)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        mousePos.z = 0;

        Vector3 diff = (mousePos - weaponParent.transform.position);
        float angle = (Mathf.Atan2(diff.y, diff.x)) * Mathf.Rad2Deg;

        weaponParent.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    /// <summary>
    /// Handles firing the weapon.
    /// </summary>
    private void OnWeaponFire(InputAction.CallbackContext ctx)
    {
        weapon.Fire();
    }

    /// <summary>
    /// Handles reloading the weapon.
    /// </summary>
    private void OnWeaponReload(InputAction.CallbackContext val)
    {
        weapon.Reload();
    }
}
