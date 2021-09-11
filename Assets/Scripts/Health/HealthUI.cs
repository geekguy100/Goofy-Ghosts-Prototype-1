/*****************************************************************************
// File Name :         HealthUI.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : Displays an entity's health on the UI.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthUI : MonoBehaviour
{
    [Tooltip("The channel to receive health change calls from.")]
    [SerializeField] private HealthInfoChannelSO entityHealthChangeChannel;

    [Tooltip("The time in seconds that the health bar should lerp to the entity's current health.")]
    [SerializeField] private float lerpTime;

    /// <summary>
    /// The slider component attached to the game object.
    /// </summary>
    private Slider slider;

    #region -- Subbing and Unsubbing to Events --
    private void OnEnable()
    {
        entityHealthChangeChannel.OnHealthChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        entityHealthChangeChannel.OnHealthChanged -= UpdateSlider;
    }
    #endregion

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Updates the slider to the entity's current health.
    /// </summary>
    /// <param name="healthInfo">The entity's current health information.</param>
    private void UpdateSlider(HealthInfo healthInfo)
    {
        if (slider.maxValue != healthInfo.MaxHealth)
        {
            slider.maxValue = healthInfo.MaxHealth;
            slider.value = slider.maxValue;
        }

        StartCoroutine(LerpSlider(healthInfo));
    }

    /// <summary>
    /// Lerps the slider to the entity's current health.
    /// </summary>
    /// <param name="healthInfo">The entity's current health information.</param>
    private IEnumerator LerpSlider(HealthInfo healthInfo)
    {
        float currentTime = 0f;
        float initialValue = slider.value;
        while(currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;
            slider.value = Mathf.Lerp(initialValue, healthInfo.CurrentHealth, currentTime / lerpTime);
            yield return null;
        }
    }
}
