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
        print("Door unlocked.");
        acceptPlayer = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Door has been hit");
        if (collision.gameObject.CompareTag("Player") && acceptPlayer)
        {
            Destroy(gameObject);
        }
    }
}
