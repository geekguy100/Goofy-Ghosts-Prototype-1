/*****************************************************************************
// File Name :         GuardSiphonBehavior.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Defines behaviour for when Guards are siphoned by the player.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class GuardSiphonBehavior : MonoBehaviour, ISiphonable
{
    [Tooltip("The HealthManager of the entity to siphon from.")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private float healthToSiphon;

    [Tooltip("The key the guard is holding.")]
    [SerializeField] private Key key;

    [SerializeField] private float stunTime = 3f;

    [SerializeField] private AudioClipSO siphonSFX;
    [SerializeField] private AudioClipChannelSO sfxChannel;

    public void OnSiphoned()
    {
        sfxChannel.RaiseEvent(siphonSFX);
        healthManager.CurrentHealth += healthToSiphon;
        //NOTE: Would remove health from guard as well, but that's not a part of our game.

        // Drop key if Guard has one on him.
        if (key != null)
        {
            DropKey();
        }

        StartCoroutine(BecomeStunned());
    }

    /// <summary>
    /// Unparents the key from the guard, dropping it into the world.
    /// </summary>
    private void DropKey()
    {
        key.transform.SetParent(null);
        key.OnDropped();
        key = null;
    }

    private IEnumerator BecomeStunned()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<GuardAI>().OnStunned();
        yield return new WaitForSeconds(stunTime);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<GuardAI>().OnUnstunned();
    }
}