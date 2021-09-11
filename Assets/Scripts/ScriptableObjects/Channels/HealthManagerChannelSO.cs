/*****************************************************************************
// File Name :         HealthManagerChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

public class HealthManagerChannelSO : ScriptableObject
{
    public UnityAction<HealthManager> OnEventRaised;

    public void RaiseEvent(HealthManager healthManager)
    {
        OnEventRaised?.Invoke(healthManager);
    }
}
