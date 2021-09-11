/*****************************************************************************
// File Name :         PickupsContainer.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A UI container that holds all collectables the player is in possession of.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PickupsContainer : MonoBehaviour
{
    private List<CollectablePair?> collectables;

    [Tooltip("The channel to subscribe to for collectable pickup events.")]
    [SerializeField] private CollectableDataChannelSO channel;

    private void OnEnable()
    {
        channel.OnCollectableObtained += AddPickup;
    }

    private void OnDisable()
    {
        channel.OnCollectableObtained -= AddPickup;
    }

    private void Awake()
    {
        collectables = new List<CollectablePair?>();
    }

    /// <summary>
    /// Adds a pickup to the container.
    /// </summary>
    /// <param name="data">The data of the pickup to add.</param>
    public void AddPickup(CollectableData data)
    {
        GameObject pickup = Instantiate(data.Icon.gameObject, transform);
        CollectablePair pair = new CollectablePair(pickup, data);
        collectables.Add(pair);
    }

    /// <summary>
    /// Removes a pickup from the container.
    /// </summary>
    /// <param name="data">The data of the pickup to remove.</param>
    public void RemovePickup(CollectableData data)
    {
        CollectablePair? pairToRemove = collectables.Where(t => t.Value.Data == data).FirstOrDefault();
        if (pairToRemove != null)
        {
            collectables.Remove(pairToRemove);
        }
    }
}

public struct CollectablePair
{
    private GameObject clone;
    public GameObject Clone { get { return clone; } }
    private CollectableData data;
    public CollectableData Data { get { return data; } }

    public CollectablePair(GameObject clone, CollectableData data)
    {
        this.clone = clone;
        this.data = data;
    }
}
