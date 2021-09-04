using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityManager : MonoBehaviour
{
    private IAbility ability;

    private void Awake()
    {
        ability = gameObject.AddComponent<PhaseAbility>();
    } 

    public void OnAbilityActivate()
    {
        print("Ability on!");
        ability.Activate();
    }
}
