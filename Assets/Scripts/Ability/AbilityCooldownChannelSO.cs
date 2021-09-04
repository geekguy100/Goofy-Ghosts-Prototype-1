using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Ability Cooldown Event Channel")]
public class AbilityCooldownChannelSO : ScriptableObject
{
    public UnityAction<float> OnCooldownChange;

    public void RaiseEvent(float cooldownTime)
    {
        OnCooldownChange?.Invoke(cooldownTime);
    }
}