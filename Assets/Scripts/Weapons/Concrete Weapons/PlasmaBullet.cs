/*****************************************************************************
// File Name :         PlasmaBullet.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Concrete Bullet, the PlasmaBullet, is fired out of the Plasma Gun.
*****************************************************************************/
using UnityEngine;

public class PlasmaBullet : Bullet
{
    [Tooltip("The number of times the bullet will bounce until it is destroyed.")]
    [SerializeField] private int maxBounces;
    /// <summary>
    /// The number of times the bullet has bounced.
    /// </summary>
    private int currentBounces;

    [Header("Audio")]
    [Tooltip("The SFX Channel.")]
    [SerializeField] private AudioClipChannelSO sfxChannel;

    [Tooltip("The AudioClipSO that holds the bounce SFX.")]
    [SerializeField] private AudioClipSO bounceSFX;

    /// <summary>
    /// Destroy the bullet on collision with game object tagged "Player".
    /// </summary>
    /// <param name="collision">The Collision2D the bullet collided with.</param>
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // If we didn't collide with an enemy, bounce the ball.
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            sfxChannel.RaiseEvent(bounceSFX);

            if (currentBounces >= maxBounces)
            {
                Destroy(gameObject);
            }
            else
            {
                // If the bullet's velocity drops below our set speed,
                // bring it back up to speed while keeping its direction the same.
                if (rb.velocity.magnitude < bulletSpeed)
                {
                    Vector3 dir = rb.velocity.normalized;
                    dir *= bulletSpeed;
                    rb.velocity = dir;
                }
                ++currentBounces;
            }
        }
        // If we collided with an Enemy, check to see if it is siphonable.
        else
        {
            ISiphonable siphonable = collision.gameObject.GetComponent<ISiphonable>();
            siphonable.OnSiphoned();
            // TODO: Play siphon sound.
            Destroy(gameObject);
        }
    }
}