/*****************************************************************************
// File Name :         HealthInfoChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A channel to broadcast information on an entity's current health information.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/Health Info Channel", fileName = "New Health Info Channel")]
public class HealthInfoChannelSO : ScriptableObject
{
    public UnityAction<HealthInfo> OnHealthChanged;

    public void RaiseEvent(HealthInfo info)
    {
        OnHealthChanged?.Invoke(info);
    }
}