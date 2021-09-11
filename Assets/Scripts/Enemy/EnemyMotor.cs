/*****************************************************************************
// File Name :         EnemyMotor.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Moves an enemy around the world.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMotor : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    /// <summary>
    /// Moves the enemy in the specified direction
    /// </summary>
    /// <param name="direction">The direction to move the enemy in.</param>
    public void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}