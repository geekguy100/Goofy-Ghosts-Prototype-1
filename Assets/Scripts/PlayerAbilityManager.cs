using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    private IAbility ability;
    [SerializeField] private AbilityCooldownChannelSO abilityCooldownChannel;

    private void Awake()
    {
        ability = gameObject.AddComponent<PhaseAbility>();
    } 

    public void OnAbilityActivate()
    {
        if (ability.IsCoolingDown())
        {
            return;
        }

        print("[PlayerAbilityManager] : ability on!");

        abilityCooldownChannel.RaiseEvent(ability.GetCooldownTime());
        ability.Activate();
    }
}
