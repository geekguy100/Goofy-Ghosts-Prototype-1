/*****************************************************************************
// File Name :         PlayerMotor.cs
// Author :            Kyle Grenier
// Creation Date :     09/03/2021
//
// Brief Description : Responsible for accepting input and moving the player's game object.
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    /// <summary>
    /// A PlayerControls object. Used to subscribe and unsubscribe to input events.
    /// </summary>
    private PlayerControls controls;
    /// <summary>
    /// Caching controls.Player.Move since we'll be referencing it a lot.
    /// </summary>
    private InputAction movementControls;

    // Components
    /// <summary>
    /// The player's Rigidbody2D component.
    /// </summary>
    private Rigidbody2D rb;

    // Movement fields
    [Tooltip("The speed the player moves at.")]
    [SerializeField] private float movementSpeed = 1;
    /// <summary>
    /// A Vector2 that holds the player's movement input.
    /// </summary>
    private Vector2 movementInput;

    [Tooltip("The Transform that holds the player's model (sprite).")]
    [SerializeField] private Transform playerModel;

    #region -- Subscribing / Unsubscribing to Input Events --
    private void OnEnable()
    {
        movementControls = controls.Player.Move;
        movementControls.performed += RotatePlayer;
        movementControls.Enable();
    }

    private void OnDisable()
    {
        movementControls.Disable();
        movementControls = null;
    }
    #endregion

    /// <summary>
    /// Initializing controls and getting components.
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Moves the player game object.
    /// </summary>
    /// <param name="movementVector">The vector that stores the player's movement input.</param>
    private void MovePlayer(Vector2 movementVector)
    {
        rb.MovePosition(rb.position + movementVector * Time.fixedDeltaTime * movementSpeed);
    }

    /// <summary>
    /// Rotates the player's model according to the direction of movement.
    /// </summary>
    /// <param name="context">The input system's callback context.</param>
    private void RotatePlayer(InputAction.CallbackContext context)
    {
        // Rotate the player model towards the movement input.
        Vector2 input = context.ReadValue<Vector2>();

        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        StopAllCoroutines();
        StartCoroutine(LerpRotation(Quaternion.AngleAxis(angle - 90f, Vector3.forward)));
    }

    /// <summary>
    /// Lerp the player's current rotation to the provided final rotation.
    /// </summary>
    /// <param name="finalRot">The rotation to lerp to.</param>
    private IEnumerator LerpRotation(Quaternion finalRot)
    {
        const float ROT_TIME = 0.25f;
        float currentTime = 0f;

        Quaternion initialRot = playerModel.localRotation;

        while (currentTime < ROT_TIME)
        {
            currentTime += Time.deltaTime;
            playerModel.localRotation = Quaternion.Lerp(initialRot, finalRot, currentTime / ROT_TIME);
            yield return null;
        }
    }

    /// <summary>
    /// Move the player based on movement input.
    /// </summary>
    private void FixedUpdate()
    {
        movementInput = movementControls.ReadValue<Vector2>();
        MovePlayer(movementInput);
    }
}