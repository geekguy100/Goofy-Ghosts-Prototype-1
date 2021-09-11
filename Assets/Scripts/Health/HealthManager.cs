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
    [SerializeField] private HealthDataSO healthData;

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

            HealthInfo info = new HealthInfo(healthData.MaxHealth, currentHealth);
            healthData.HealthChangeChannel.RaiseEvent(info);

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

/// <summary>
/// A struct that holds health information. Passed into the on health change event.
/// </summary>
public struct HealthInfo
{
    private float maxHealth;
    public float MaxHealth { get { return maxHealth; } }

    private float currentHealth;
    public float CurrentHealth { get { return currentHealth; } }

    public HealthInfo(float maxHealth, float currentHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
    }
}
