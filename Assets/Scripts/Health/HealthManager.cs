/*****************************************************************************
// File Name :         HealthManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Component that manage's an entity's health.
*****************************************************************************/
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Tooltip("The Health ScriptableObject used to initialize the entity's health.")]
    [SerializeField] private Health healthData;

    /// <summary>
    /// The entity's current health.
    /// </summary>
    private float currentHealth;
    /// <summary>
    /// The entity's current health.
    /// </summary>
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
            healthData.HealthChangeChannel.RaiseEvent(currentHealth);

            // If the player's health is empty, raise the healthEmpty event.
            if (currentHealth <= 0)
            {
                healthData.HealthEmptyChannel.RaiseEvent();
            }
        }
    }

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Public method used for a manager class to initialize this Health component.
    /// </summary>
    public void Init()
    {
        if (healthData.BroadcastOnInit)
        {
            CurrentHealth = healthData.MaxHealth;
        }
        else
        {
            currentHealth = healthData.MaxHealth;
        }
    }

    /// <summary>
    /// Returns true if the entity's current health is less-than or equal-to 0.
    /// </summary>
    /// <returns>True if the player's current health is less-than or equal-to 0.</returns>
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
