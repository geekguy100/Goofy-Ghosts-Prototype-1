/*****************************************************************************
// File Name :         PlayerAbilityManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Responsible for managing the player's abilities.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityManager : MonoBehaviour
{
    /// <summary>
    /// The player control script.
    /// </summary>
    private PlayerControls controls;

    /// <summary>
    /// The currently equipped ability.
    /// </summary>
    private IAbility ability;

    [Tooltip("Channel to broadcast ability cooldown to.")]
    [SerializeField] private AbilityCooldownChannelSO abilityCooldownChannel;

    #region -- Subscribing and Unsubscribing to Input Events --
    private void OnEnable()
    {
        controls.Player.AbilityActivate.performed += OnAbilityActivate;
        controls.Player.AbilityActivate.Enable();
    }

    private void OnDisable()
    {
        controls.Player.AbilityActivate.Disable();
    }
    #endregion

    /// <summary>
    /// Initializing player controls and adding default ability.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        ability = gameObject.AddComponent<PhaseAbility>();
    } 

    /// <summary>
    /// Activates the current ability.
    /// </summary>
    /// <param name="ctx">Input System callback context</param>
    public void OnAbilityActivate(InputAction.CallbackContext ctx)
    {
        if (ability.IsCoolingDown())
        {
            return;
        }

        print("[PlayerAbilityManager] : ability on!");

        abilityCooldownChannel.RaiseEvent(ability.GetCooldownTime());
        ability.Activate();
    }
}
