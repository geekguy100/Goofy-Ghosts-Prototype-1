/*****************************************************************************
// File Name :         TransformChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/12/2021
//
// Brief Description : A SO that accepts and broadcasts an event carrying a Transform component.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/Transform Channel", fileName = "New Transform Channel")]
public class TransformChannelSO : ScriptableObject
{
    public UnityAction<Transform> OnEventRasied;

    public void RaiseEvent(Transform t)
    {
        OnEventRasied?.Invoke(t);
    }
}
