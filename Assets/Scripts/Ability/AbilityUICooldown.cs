using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class AbilityUICooldown : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private AbilityCooldownChannelSO abilityCooldownChannel;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        abilityCooldownChannel.OnCooldownChange += (float value) => { StartCoroutine(ChangeSlider(value)); };
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