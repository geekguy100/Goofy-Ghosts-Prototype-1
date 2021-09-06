/*****************************************************************************
// File Name :         AbilityUsedChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/04/2021
//
// Brief Description : A SO reponsible for accepting and broadcasting calls when ability's are used.
*****************************************************************************/
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Ability Used Event Channel")]
public class AbilityUsedChannelSO : ScriptableObject
{
    public UnityAction<float> OnAbilityUsed;

    public void RaiseEvent(float cooldownTime)
    {
        OnAbilityUsed?.Invoke(cooldownTime);
    }
}