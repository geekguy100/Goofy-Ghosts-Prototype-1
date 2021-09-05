using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    private PlayerControls controls;
    private InputAction movementControls;

    // Components
    private Rigidbody2D rb;

    // Movement fields
    [Tooltip("The speed the player moves at.")]
    [SerializeField] private float movementSpeed = 1;

    #region -- Subscribing / Unsubscribing to Input Events --
    private void OnEnable()
    {
        movementControls = controls.Player.Move;
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

    private void FixedUpdate()
    {
        MovePlayer(movementControls.ReadValue<Vector2>());
    }
}