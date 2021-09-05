/*****************************************************************************
// File Name :         Bullet.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Adds a force to the bullet's rigidbody upon instantiation.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// The bullet's Rigidbody2D component.
    /// </summary>
    private Rigidbody2D rb;

    [Tooltip("The speed of the bullet upon instantiation.")]
    [SerializeField] private float bulletSpeed;

    /// <summary>
    /// Getting the Rigidbody2D component.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Adds a force to the bullet.
    /// </summary>
    private void Start()
    {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
