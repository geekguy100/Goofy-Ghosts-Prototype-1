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

    [Tooltip("The channel that accepts subscribers to the game paused event.")]
    [SerializeField] private BoolChannelSO gamePausedChannel;


    /// <summary>
    /// Gets the IWeapon component.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        weapon = weaponParent.GetComponentInChildren<IWeapon>();
    }

    #region -- Subscribing / Unsubscribing to Events --
    /// <summary>
    /// Subscribe to all of the input events.
    /// </summary>
    private void OnEnable()
    {
        controls.Player.WeaponFire.performed += OnWeaponFire;
        controls.Player.WeaponFire.Enable();

        controls.Player.WeaponReleaseFire.performed += OnWeaponFireRelease;
        controls.Player.WeaponReleaseFire.Enable();

        controls.Player.Rotate.performed += OnRotate;
        controls.Player.Rotate.Enable();

        gamePausedChannel.OnEventRaised += ToggleInput;
    }

    /// <summary>
    /// Unsubscribe to all of the input events.
    /// </summary>
    private void OnDisable()
    {
        controls.Player.WeaponFire.Disable();
        controls.Player.WeaponReleaseFire.Disable();
        controls.Player.Rotate.Disable();

        gamePausedChannel.OnEventRaised -= ToggleInput;
    }
    #endregion

    /// <summary>
    /// Rotates the weapon according to the cursor's position.
    /// </summary>
    /// <param name="value">The mouse cursor's position.</param>
    private void OnRotate(InputAction.CallbackContext ctx)
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
    /// <param name="ctx">The input system's callback context.</param>
    private void OnWeaponFire(InputAction.CallbackContext ctx)
    {
        weapon.Fire();
    }

    /// <summary>
    /// Invoked when the player releases the weapon fire.
    /// </summary>
    /// <param name="ctx">The input system's callback context.</param>
    private void OnWeaponFireRelease(InputAction.CallbackContext ctx)
    {
        weapon.ReleaseFire();
    }

    /// <summary>
    /// Handles reloading the weapon.
    /// </summary>
    private void OnWeaponReload(InputAction.CallbackContext val)
    {
        weapon.Reload();
    }

    /// <summary>
    /// Toggles player input.
    /// </summary>
    /// <param name="paused">True if the game is paused and input should be disabled.</param>
    private void ToggleInput(bool paused)
    {
        if (paused)
        {
            controls.Player.WeaponFire.Disable();
            controls.Player.WeaponReleaseFire.Disable();
        }
        else
        {
            controls.Player.WeaponFire.Enable();
            controls.Player.WeaponReleaseFire.Enable();
        }
    }
}