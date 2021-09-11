/*****************************************************************************
// File Name :         ICollectable.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Interface for in-game collectables (keys, etc).
*****************************************************************************/
using UnityEngine;

public abstract class ICollectable : MonoBehaviour
{
    [Header("Collectable Data")]
    [Tooltip("The collectable's data.")]
    [SerializeField] protected CollectableData data;
    [Tooltip("Channel to broadcast pickup events to.")]
    [SerializeField] protected CollectableDataChannelSO collectableChannel;

    /// <summary>
    /// Invoked when a Rigidbody2D enters the trigger.
    /// </summary>
    /// <param name="col">The Collider2D that entered the trigger.</param>
    protected void OnTriggerEnter2D(Collider2D col)
    {
        PerformAction();
    }

    protected abstract void PerformAction();
}
