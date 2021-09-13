/*****************************************************************************
// File Name :         AbilityUICooldown.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : Responsible for updating UI to an indicate ability's cooldown time.
*****************************************************************************/
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class AbilityUICooldown : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private FloatChannelSO abilityUsedChannel;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        abilityUsedChannel.OnEventRaised += StartSliderChange;
    }

    private void OnDisable()
    {
        abilityUsedChannel.OnEventRaised -= StartSliderChange;
    }

    private void StartSliderChange(float value)
    {
        StartCoroutine(ChangeSlider(value));
    }

    private IEnumerator ChangeSlider(float value)
    {
        float maxTime = value;
        float currentTime = value;

        // Decreasing slider
        while(currentTime > 0)
        {
            slider.value = currentTime / maxTime;
            currentTime -= Time.deltaTime;
            yield return null;
        }


        // Increasing slider

        // The time it takes to fill the bar back up.
        const float INCREASE_TIME = 0.05f;
        currentTime = 0f;

        while (currentTime < INCREASE_TIME)
        {
            slider.value = currentTime / INCREASE_TIME;
            currentTime += Time.deltaTime;
            yield return null;
        }

        slider.value = 1;
    }
}