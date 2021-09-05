/*****************************************************************************
// File Name :         Bullet.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Abstract bullet clas. Adds a force to the bullet's rigidbody upon instantiation.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    /// <summary>
    /// The bullet's Rigidbody2D component.
    /// </summary>
    private Rigidbody2D rb;

    [Tooltip("The speed of the bullet upon instantiation.")]
    [SerializeField] private float bulletSpeed;

    [Tooltip("Time till bullet is destoyed.")]
    [SerializeField] private float destroyTime;

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
        Destroy(gameObject, destroyTime);
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);
}
