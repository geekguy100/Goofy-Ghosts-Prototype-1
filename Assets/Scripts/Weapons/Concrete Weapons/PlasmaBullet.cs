/*****************************************************************************
// File Name :         PlasmaBullet.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Concrete Bullet, the PlasmaBullet, is fired out of the Plasma Gun.
                       Is destroyed on collision with the player.
*****************************************************************************/
using UnityEngine;

// TODO: Destroyed in a number of bounced instead of a time??
public class PlasmaBullet : Bullet
{
    /// <summary>
    /// Destroy the bullet on collision with game object tagged "Player".
    /// </summary>
    /// <param name="collision">The Collision2D the bullet collided with.</param>
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
