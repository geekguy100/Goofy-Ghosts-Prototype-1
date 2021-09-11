/*****************************************************************************
// File Name :         HealthDataSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A SO that holds an entity's health data.
*****************************************************************************/
using UnityEngine;

[CreateAssetMenu(menuName = "Health/Health Data", fileName = "New Health Asset")]
public class HealthDataSO : ScriptableObject
{
    [Tooltip("The maximum and starting health of the entity.")]
    [SerializeField] private float maxHealth;
    public float MaxHealth { get { return maxHealth; } }

    [Tooltip("True if the on health change event should be invoked when initializing the entity's health.")]
    [SerializeField] private bool broadcastOnInit;
    public bool BroadcastOnInit { get { return broadcastOnInit; } }

    [Tooltip("A channel used to raise an on health change event to.")]
    [SerializeField] private HealthInfoChannelSO healthChangeChannel;
    public HealthInfoChannelSO HealthChangeChannel { get { return healthChangeChannel; } }

    [Tooltip("A channel used to raise an on death event to.")]
    [SerializeField] private VoidChannelSO healthEmptyChannel;
    public VoidChannelSO HealthEmptyChannel { get { return healthEmptyChannel; } }
}