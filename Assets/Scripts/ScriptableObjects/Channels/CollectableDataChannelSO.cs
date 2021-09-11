/*****************************************************************************
// File Name :         CollectableDataChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/11/2021
//
// Brief Description : A channel that receives subscribes to and broadcasts a collectable obtained event.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/CollectableData Channel", fileName ="New CollectableData Channel")]
public class CollectableDataChannelSO : ScriptableObject
{
    public UnityAction<CollectableData> OnCollectableObtained;

    public void RaiseEvent(CollectableData collectable)
    {
        OnCollectableObtained?.Invoke(collectable);
    }
}
