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

    [Tooltip("The channel that accepts subscribers to the game pause event.")]
    [SerializeField] private BoolChannelSO gamePausedChannel;


    #region -- Subscribing and Unsubscribing to Events --
    private void OnEnable()
    {
        controls.Player.AbilityActivate.performed += OnAbilityActivate;
        controls.Player.AbilityActivate.Enable();

        gamePausedChannel.OnEventRaised += ToggleInput;
    }

    private void OnDisable()
    {
        controls.Player.AbilityActivate.Disable();

        gamePausedChannel.OnEventRaised -= ToggleInput;
    }
    #endregion

    /// <summary>
    /// Initializing player controls and adding default ability.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        ability = GetComponent<IAbility>();
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

        ability.Activate();
    }

    /// <summary>
    /// Toggles player input.
    /// </summary>
    /// <param name="gamePaused">True if the game is paused and input should be disabled.</param>
    private void ToggleInput(bool gamePaused)
    {
        // Disables input if game is paused,
        // Enables input if game is not paused.
        if (gamePaused)
        {
            controls.Player.AbilityActivate.Disable();
        }
        else
        {
            controls.Player.AbilityActivate.Enable();
        }
    }
}
