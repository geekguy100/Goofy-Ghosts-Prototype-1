/*****************************************************************************
// File Name :         LockedDoor.cs
// Author :            Kyle Grenier
// Creation Date :     09/13/2021
//
// Brief Description : Unlocks the door if the player has collected the key.
*****************************************************************************/
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private CollectableDataChannelSO collectableChannel;
    [SerializeField] private AudioClipSO deniedSFX;
    [SerializeField] private AudioClipSO unlockedSFX;
    [SerializeField] private AudioClipChannelSO sfxChannel;

    private bool acceptPlayer;

    private void OnEnable()
    {
        collectableChannel.OnCollectableObtained += Unlock;
    }

    private void OnDisable()
    {
        collectableChannel.OnCollectableObtained -= Unlock;
    }

    private void Unlock(CollectableData data)
    {
        acceptPlayer = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && acceptPlayer)
        {
            sfxChannel.RaiseEvent(unlockedSFX);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            sfxChannel.RaiseEvent(deniedSFX);
        }
    }
}
