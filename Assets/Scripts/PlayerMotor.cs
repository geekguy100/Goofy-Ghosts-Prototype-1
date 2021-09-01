using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;

    // Movement fields
    /// <summary>
    /// The vector that stores the player's movement input.
    /// </summary>
    private Vector2 movementVector;

    [Tooltip("The speed the player moves at.")]
    [SerializeField] private float movementSpeed = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// Moves the player game object.
    /// </summary>
    private void MovePlayer()
    {
        rb.MovePosition(rb.position + movementVector * Time.fixedDeltaTime * movementSpeed);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}